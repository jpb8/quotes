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

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureRepository _repo;

        public FeaturesController(IFeatureRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Feature>>> GetFeatures()
        {
            var features = await _repo.GetFeaturesAsync();

            return Ok(features);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feature>> GetFeature(int id)
        {
            return  await _repo.GetFeatureByIdAsync(id);
        }

        [HttpGet("ResourceTypes")]
        public async Task<ActionResult<IReadOnlyList<ResourceType>>> GetResourceTypes(int id)
        {
            return Ok(await _repo.GetResourceTypesAsync());
        }

    }
}
