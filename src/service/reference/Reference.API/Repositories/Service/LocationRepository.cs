using AutoMapper;
using MongoDB.Bson;
using Reference.API.Entities;
using Reference.API.Model;
using Reference.API.Repositories.Data;
using Reference.API.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reference.API.Repositories.Service
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IMongoRepository<Location> _context;
        private readonly IMapper _mapper;
        public LocationRepository(IMongoRepository<Location> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateLocation(LocationModel location)
        {
            await _context.InsertOneAsync(_mapper.Map<Location>(location));
        }

        public async Task<bool> DeleteLocation(string id)
        {
            return await _context.DeleteByIdAsync(ObjectId.Parse(id));
        }

        public async Task<LocationModel> GetLocation(string id)
        {
            var result = await _context
            .FindByIdAsync(id);

            return _mapper.Map<LocationModel>(result);
        }

        public async Task<IEnumerable<LocationModel>> GetLocationByName(string name)
        {
            var result = await _context
                .FilterBy(r => r.Name == name);

            return _mapper.Map<IEnumerable<LocationModel>>(result);
        }

        public async Task<IEnumerable<LocationModel>> GetLocationByType(string type)
        {
            var result = await _context
                .FilterBy(r => r.Type == type);

            return _mapper.Map<IEnumerable<LocationModel>>(result);
        }

        public async Task<IEnumerable<LocationModel>> GetLocations()
        {
            var result = await _context
                            .FilterBy(r => true);

            return _mapper.Map<IEnumerable<LocationModel>>(result);
        }

        public async Task<bool> UpdateLocation(LocationModel location)
        {
            return await _context.ReplaceOneAsync(_mapper.Map<Location>(location));
        }
    }
}
