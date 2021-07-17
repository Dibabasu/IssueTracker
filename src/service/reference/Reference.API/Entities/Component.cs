﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Reference.API.Entities
{
    public class Component
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
