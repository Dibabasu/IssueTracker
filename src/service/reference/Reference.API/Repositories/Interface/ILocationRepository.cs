using Reference.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reference.API.Repositories.Interface
{
  public  interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetLocations();
        Task<Location> GetLocation(string id);
        Task<IEnumerable<Location>> GetLocationByName(string name);
        Task CreateLocation(Location Location);
        Task<bool> UpdateLocation(Location Location);
        Task<bool> DeleteLocation(string id);
    }
}
