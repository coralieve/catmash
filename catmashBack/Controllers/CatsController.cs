using catmashBack.Models;
using System.Web.Http;
using Newtonsoft.Json;
using MongoDB.Bson;
using System.Net.Http;
using System.Net;
using System;

namespace catmashBack.Controllers
{
    public class CatsController : ApiController
    {
        
        // GET: api/Cats
        public string Get()
        {
            return MongoInfo.Instance.GetAllCats().ToJson();
        }

        [Route("api/rank")]
        [HttpGet]
        public string Rank()
        {
            return MongoInfo.Instance.GetAllCats(true).ToJson();
        }

        [Route("api/game")]
        [HttpGet]
        public string Game()
        {
            return MongoInfo.Instance.GetTwoRandomCat().ToJson();
        }

        // GET: api/Cats/c8a
        public string Get(string id)
        {
            Cat found = MongoInfo.Instance.GetCat(id);
            if (found ==  null)
            {
                HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No cat with ID = {0}", id)),
                    ReasonPhrase = "Cat ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
            return found.ToJson();
        }

        // POST: api/Cats
        public HttpResponseMessage Post(Cat value)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                MongoInfo.Instance.AddNewCat(value);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ModelState);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT: api/Cats/5
        public void Put(string id, Cat value)
        {
            
        }

        [Route("api/result/{id:string}")]
        [HttpPut]
        public HttpResponseMessage Result(string id, ResultParameters info)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {

                if(AuthApp.allAuthorisedAppId.Contains(info.appId))
                    MongoInfo.Instance.Game(id, info.opponentCatId, info.outcome);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.Forbidden, ModelState);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ModelState);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE: api/Cats/5
        public void Delete(int id)
        {
        }
    }
}
