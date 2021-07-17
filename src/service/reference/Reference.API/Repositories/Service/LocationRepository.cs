using MongoDB.Driver;
using Reference.API.Data;
using Reference.API.Entities;
using Reference.API.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reference.API.Repositories.Service
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IReferenceContext _context;
        public LocationRepository(IReferenceContext context)
        {
            _context = context;
        }
        public async Task CreateLocation(Location Location)
        {
            await _context.Locations.InsertOneAsync(Location);
        }

        public async Task<bool> DeleteLocation(string id)
        {
            FilterDefinition<Location> filter = Builders<Location>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                .Locations
                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<Location> GetLocation(string id)
        {
            return await _context
                .Locations
                .Find(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Location>> GetLocationByName(string name)
        {
            FilterDefinition<Location> filter = Builders<Location>.Filter.Eq(p => p.Name, name);

            return await _context
                 .Locations
                 .Find(filter)
                 .ToListAsync();
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await _context
                 .Locations
                 .Find(p => true)
                 .ToListAsync();
        }

        public async Task<bool> UpdateLocation(Location Location)
        {
            var updateResult = await _context
                .Locations
                .ReplaceOneAsync(filter: g => g.Id == Location.Id, replacement: Location);

            return updateResult.IsAcknowledged
                && updateResult.ModifiedCount > 0;
        }
    }
}
