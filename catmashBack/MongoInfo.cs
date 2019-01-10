using catmashBack.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public string GetAllCats()
        {
            IMongoCollection<Cat> catscol = _currentDataBase.GetCollection<Cat>("CATS");
            return catscol.Find(new BsonDocument()).ToList<Cat>().ToJson();
        }
    }
    
}