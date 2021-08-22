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
    public class ComponentMapping : Profile
    {
        public ComponentMapping()
        {
            CreateMap<Component, ComponentModel>()
                .ForMember(u => u.ComponentName, opt => opt.MapFrom(x => x.Name))
                .ForMember(u => u.Id, opt => opt.MapFrom(x => x.Id.ToString()));

            CreateMap<ComponentModel, Component>()
               .ForMember(u => u.Name, opt => opt.MapFrom(x => x.ComponentName))
               .ForMember(u => u.Id, opt => opt.MapFrom(x => ObjectId.Parse(x.Id)));

            CreateMap<CreateComponentDTO,Component>()
                .ForMember(u => u.Name, opt => opt.MapFrom(x => x.ComponentName));
        }
    }
}
