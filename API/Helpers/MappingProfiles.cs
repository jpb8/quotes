﻿using API.Dtos;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Feature, FeatureToReturnDto>()
                .ForMember(d => d.Project, o => o.MapFrom(s => s.Project.Name))
                .ForMember(d => d.ResourceType, o => o.MapFrom(s => s.ResourceType.Name));
        }
        
    }
}