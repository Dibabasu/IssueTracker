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
    public class ComponentRepository : IComponentRepository
    {
        private readonly IMongoRepository<Component> _context;
        private readonly IMapper _mapper;
        public ComponentRepository(IMongoRepository<Component> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task CreateComponent(CreateComponentDTO component)
        {
           
            await _context.InsertOneAsync(_mapper.Map<Component>(component));
        }

        public async Task<bool> DeleteComponent(string id)
        {
            return await _context.DeleteByIdAsync(ObjectId.Parse(id));
        }

        public async Task<ComponentModel> GetComponent(string id)
        {
            var result = await _context
                .FindByIdAsync(id);

            return _mapper.Map<ComponentModel>(result);

        }

        public async Task<IEnumerable<ComponentModel>> GetComponentByName(string name)
        {

            var result = await _context
                .FilterBy(r => r.Name == name);

            return _mapper.Map<IEnumerable<ComponentModel>>(result);

        }

        public async Task<IEnumerable<ComponentModel>> GetComponents()
        {
            var result = await _context
                 .FilterBy(r => true);

            return _mapper.Map<IEnumerable<ComponentModel>>(result);

        }

        public async Task<bool> UpdateComponent(ComponentModel component)
        {

            return await _context.ReplaceOneAsync(_mapper.Map<Component>(component));
        }
    }
}
