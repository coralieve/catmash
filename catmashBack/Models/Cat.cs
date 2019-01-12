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
        [BsonElement(elementName: "elo")]
        [BsonDefaultValue(EloUtils.ELONEWCOMER)]
        public int elo { get; set; }
        [BsonElement(elementName: "k")]
        [BsonDefaultValue(EloUtils.KNEWCOMER)]
        public int k { get; set; }
        [BsonElement(elementName: "nbGame")]
        [BsonDefaultValue(0)]
        public int nbGame { get; set; }
    }
}