using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Core.Interfaces;
using Core.Specifications;
using API.Dtos;
using AutoMapper;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FeaturesController : ControllerBase
    {
        private readonly IGenericRepository<Feature> _featuresRepo;
        private readonly IGenericRepository<ResourceType> _resourceTypeRepo;

        public IMapper _mapper;

        public FeaturesController(
            IGenericRepository<Feature> featuresRepo, 
            IGenericRepository<ResourceType> resourceTypeRepo,
            IMapper mapper
            )
        {
            _featuresRepo = featuresRepo;
            _resourceTypeRepo = resourceTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<FeatureToReturnDto>>> GetFeatures()
        {
            var spec = new FeaturesWithResourceTypeAndProjecSpecification();

            var features = await _featuresRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Feature>, IReadOnlyList<FeatureToReturnDto>>(features));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeatureToReturnDto>> GetFeature(int id)
        {
            var spec = new FeaturesWithResourceTypeAndProjecSpecification(id);
            var feature = await _featuresRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Feature, FeatureToReturnDto>(feature);
        }

        [HttpGet("ResourceTypes")]
        public async Task<ActionResult<IReadOnlyList<ResourceType>>> GetResourceTypes(int id)
        {
            return Ok(await _resourceTypeRepo.ListAllAsync());
        }

    }
}
