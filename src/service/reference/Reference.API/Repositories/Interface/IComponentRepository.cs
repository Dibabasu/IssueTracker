using Reference.API.Entities;
using Reference.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reference.API.Repositories.Interface
{
    public  interface IComponentRepository
    {
        Task<IEnumerable<ComponentModel>> GetComponents();
        Task<ComponentModel> GetComponent(string id);
        Task<IEnumerable<ComponentModel>> GetComponentByName(string name);
        Task CreateComponent(ComponentModel component);
        Task<bool> UpdateComponent(ComponentModel component);
        Task<bool> DeleteComponent(string id);
    }
}
