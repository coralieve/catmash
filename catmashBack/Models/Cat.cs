using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace catmashBack.Models
{
    [BsonIgnoreExtraElements]
    public class Cat
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement(elementName: "id")]
        public string id { get; set; }
        [BsonElement(elementName: "url")]
        public string url { get; set; }
    }
}