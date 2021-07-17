using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Reference.API.Entities;

namespace Reference.API.Data
{
    public class ReferenceContext : IReferenceContext
    {
        public ReferenceContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Components = database.GetCollection<Component>(configuration.GetValue<string>("DatabaseSettings:CollectionName:Component"));
            Locations = database.GetCollection<Location>(configuration.GetValue<string>("DatabaseSettings:CollectionName:Location"));

            ReferenceContextSeed.SeedData(Components);
            ReferenceContextSeed.SeedData(Locations);
        }

        public IMongoCollection<Location> Locations {get;}

       public IMongoCollection<Component> Components { get; }
    }
}
