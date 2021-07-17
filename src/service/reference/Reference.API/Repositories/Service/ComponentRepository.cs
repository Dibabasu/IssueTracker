using MongoDB.Driver;
using Reference.API.Data;
using Reference.API.Entities;
using Reference.API.Repositories.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reference.API.Repositories.Service
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly IReferenceContext _context;
        public ComponentRepository(IReferenceContext context)
        {
            _context = context;
        }
        public async Task CreateComponent(Component component)
        {
           await _context.Components.InsertOneAsync(component);
        }

        public async Task<bool> DeleteComponent(string id)
        {
            FilterDefinition<Component> filter = Builders<Component>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                .Components
                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<Component> GetComponent(string id)
        {
            return await _context
                .Components
                .Find(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Component>> GetComponentByName(string name)
        {
            FilterDefinition<Component> filter = Builders<Component>.Filter.Eq(p => p.Name, name);

            return await _context
                 .Components
                 .Find(filter)
                 .ToListAsync();
        }

        public async Task<IEnumerable<Component>> GetComponents()
        {
            return await _context
                 .Components
                 .Find(p => true)
                 .ToListAsync();
        }

        public async Task<bool> UpdateComponent(Component component)
        {
            var updateResult = await _context
                .Components
                .ReplaceOneAsync(filter: g => g.Id == component.Id, replacement: component);

            return updateResult.IsAcknowledged
                && updateResult.ModifiedCount > 0;
        }
    }
}
