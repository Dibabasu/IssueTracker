using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Reference.API.Entities
{
    public class Location
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        public string LocationType { get; set; }
    }
}
