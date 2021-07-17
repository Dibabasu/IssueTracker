using MongoDB.Driver;
using Reference.API.Entities;

namespace Reference.API.Data
{
    public interface IReferenceContext
    {
        IMongoCollection<Component> Components { get; }
        IMongoCollection<Location> Locations { get; }
    }
}
