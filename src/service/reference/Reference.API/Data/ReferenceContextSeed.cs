using MongoDB.Driver;
using Reference.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reference.API.Data
{
    public class ReferenceContextSeed
    {
        public static void SeedData(IMongoCollection<Component> componentCollection)
        {
            bool existProduct = componentCollection.Find(p => true).Any();
            if (!existProduct)
            {
                componentCollection.InsertManyAsync(GetPreconfiguredComponents());

            }
        }
        private static IEnumerable<Component> GetPreconfiguredComponents()
        {
            return new List<Component>()
            {
                new Component()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Configurations"

                },
                new Component()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Database"

                },
                new Component()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Network"
                }
            };
        }
        public static void SeedData(IMongoCollection<Location> locationCollection)
        {
            bool existProduct = locationCollection.Find(p => true).Any();
            if (!existProduct)
            {
                locationCollection.InsertManyAsync(GetPreconfiguredLocation());

            }
        }

        private static IEnumerable<Location> GetPreconfiguredLocation()
        {
            return new List<Location>()
            {
                new Location
                {
                    LocationType="Metro",
                    Name="Kolkata"
                },
                new Location
                {
                    LocationType="Metro",
                    Name="Delhi"
                },
                new Location
                {
                    LocationType="Metro",
                    Name="Mumbai"
                },
                new Location
                {
                    LocationType="Metro",
                    Name="Bengaluru"
                }
            };
        }
    }
}
