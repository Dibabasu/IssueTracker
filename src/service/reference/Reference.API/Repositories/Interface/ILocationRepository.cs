using Reference.API.Entities;
using Reference.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reference.API.Repositories.Interface
{
  public  interface ILocationRepository
    {
        Task<IEnumerable<LocationModel>> GetLocations();
        Task<LocationModel> GetLocation(string id);
        Task<IEnumerable<LocationModel>> GetLocationByName(string name);
        Task<IEnumerable<LocationModel>> GetLocationByType(string type);
        Task CreateLocation(LocationModel Location);
        Task<bool> UpdateLocation(LocationModel Location);
        Task<bool> DeleteLocation(string id);
    }
}
