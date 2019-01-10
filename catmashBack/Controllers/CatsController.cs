using catmashBack.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace catmashBack.Controllers
{
    public class CatsController : ApiController
    {
        
        // GET: api/Cat
        public string Get()
        {
            return MongoInfo.Instance.GetAllCats();
        }

        // GET: api/Cat/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cat
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cat/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cat/5
        public void Delete(int id)
        {
        }
    }
}
