using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Feature, FeatureToReturnDto>()
                .ForMember(d => d.Project, o => o.MapFrom(s => s.Project.Name));

            CreateMap<Project, ProjectListDto>()
                .ForMember(d => d.Features, o => o.MapFrom(s => s.Features.Count));

            CreateMap<Office, OfficeDto>()
                .ForMember(d => d.Users, o => o.MapFrom(s => s.Users.Select(t => t.Email).ToList()));
        }
        
    }
}
