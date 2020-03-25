using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blog.Models{
    public class Model{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{get;set;}
        public DateTime Created {get; set;} = DateTime.Now;
        public DateTime Updated {get; set;} = DateTime.Now;
        public bool Deleted {get; set;} = false;
    }
}