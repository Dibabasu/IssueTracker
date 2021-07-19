using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Reference.API.Common;

namespace Reference.API.Entities
{
    [BsonCollection("component")]
    public class Component : Document
    {

        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
