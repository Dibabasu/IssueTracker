using Reference.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reference.API.Repositories.Interface
{
  public  interface IComponentRepository
    {
        Task<IEnumerable<Component>> GetComponents();
        Task<Component> GetComponent(string id);
        Task<IEnumerable<Component>> GetComponentByName(string name);
        Task CreateComponent(Component component);
        Task<bool> UpdateComponent(Component component);
        Task<bool> DeleteComponent(string id);
    }
}
