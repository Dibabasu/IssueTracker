using AutoMapper;
using MongoDB.Bson;
using Reference.API.Entities;
using Reference.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reference.API.Mapping
{
    public class LocationMapping : Profile
    {
        public LocationMapping()
        {
            CreateMap<Location, LocationModel>()
                .ForMember(u => u.LocationName, opt => opt.MapFrom(x => x.Name))
                .ForMember(u => u.LocationType, opt => opt.MapFrom(x => x.Type))
                .ForMember(u => u.Id, opt => opt.MapFrom(x => x.Id.ToString()));

            CreateMap<LocationModel, Location>()
               .ForMember(u => u.Name, opt => opt.MapFrom(x => x.LocationName))
               .ForMember(u => u.Type, opt => opt.MapFrom(x => x.LocationType))
               .ForMember(u => u.Id, opt => opt.MapFrom(x => ObjectId.Parse(x.Id)));
        }
    }
}
