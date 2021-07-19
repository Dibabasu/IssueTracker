using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Reference.API.Common;


namespace Reference.API.Entities
{
    [BsonCollection("location")]
    public class Location:Document
    {
        [BsonElement("Name")]
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
