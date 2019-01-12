using catmashBack.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver.Linq;

namespace catmashBack
{
    public class MongoInfo
    {

        private IMongoClient _currentClient;
        private IMongoDatabase _currentDataBase;

        private static readonly Lazy<MongoInfo> lazy =
        new Lazy<MongoInfo>(() => new MongoInfo());

        public static MongoInfo Instance { get { return lazy.Value; } }

        private MongoInfo()
        {
            _currentClient = new MongoClient("mongodb+srv://cat:miaou@clustercatmashllive-rj7t7.azure.mongodb.net/");
            _currentDataBase = _currentClient.GetDatabase("MASH");
        }

        public Cat GetCat(string id)
        {
            IMongoCollection<Cat> catscol = _currentDataBase.GetCollection<Cat>("CATS");
            return catscol.Find(new BsonDocument("id", id)).FirstOrDefault();
            
        }

        public List<Cat> GetAllCats(bool ordered = false)
        {
            IMongoCollection<Cat> catscol = _currentDataBase.GetCollection<Cat>("CATS");
            IFindFluent<Cat, Cat> found = catscol.Find(new BsonDocument());

            //to prevent same position we use k and nbGame to determine the order
            //this favor the newcomers
            if (ordered)
                found = found.Sort("{elo: -1, k:-1, nbGame:1}");
            return found.ToList<Cat>();
        }

        public List<Cat> Reset(string mdp)
        {
            if (mdp == "OK")
            {
                IMongoCollection<Cat> catscol = _currentDataBase.GetCollection<Cat>("CATS");

                UpdateDefinition<Cat> updateDef = Builders<Cat>.Update.Set(a => a.nbGame, 0).Set(b => b.elo, EloUtils.ELONEWCOMER).Set(b => b.k, EloUtils.KNEWCOMER);
                catscol.UpdateMany(Builders<Cat>.Filter.Empty, updateDef);
            }

            return GetAllCats(true);
        }

        public List<Cat> GetTwoRandomCat()
        {
            IMongoCollection<Cat> catscol = _currentDataBase.GetCollection<Cat>("CATS");
            return catscol.AsQueryable().Sample(2).ToList<Cat>();
        }

        public void AddNewCat(Cat newOne)
        {
            IMongoCollection<Cat> catscol = _currentDataBase.GetCollection<Cat>("CATS");
            catscol.InsertOne(newOne);
        }

        /// <summary>
        /// Result game between two  cat
        /// </summary>
        /// <param name="idCat1">id cat 1</param>
        /// <param name="idCat2">id cat 2</param>
        /// <param name="result">1 cat 1 win, -1 cat 1 loss, 0 draw</param>
        public void Game(string idCat1, string idCat2, int result)
        {
            Cat cat1 = GetCat(idCat1);
            int eloCat1 = cat1.elo;
            Cat cat2 = GetCat(idCat2);
            int eloCat2 = cat2.elo;
            EloUtils.CalculateELO(ref eloCat1, ref eloCat2, (EloUtils.GameOutcome)result, Math.Max(cat1.k, cat2.k));

            UpdateElo( cat1,  eloCat1);
            UpdateElo(cat2, eloCat2);
        }

        private void UpdateElo(Cat cat, int elo)
        {
            IMongoCollection<Cat> catscol = _currentDataBase.GetCollection<Cat>("CATS");

            UpdateDefinition<Cat> updateDef = Builders<Cat>.Update.Set(a => a.nbGame, cat.nbGame+1).Set(b => b.elo, elo);
            if (cat.nbGame+1 >= EloUtils.NBGAMENEWCOMER)
                updateDef.Set(c => c.k, EloUtils.KCLASSIC);
            catscol.UpdateOne(Builders<Cat>.Filter.Eq(x => x.Id, cat.Id), updateDef);
        }
    }
    
}