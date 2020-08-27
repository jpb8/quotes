using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProjectsController : BaseApiController
    {
        private readonly IGenericRepository<Project> _projectRepo;
        private readonly IGenericRepository<Feature> _featuresRepo;

        public ProjectsController(IGenericRepository<Project> projectRepo,IGenericRepository<Feature> featuresRepo)
        {
            _projectRepo = projectRepo;
            _featuresRepo = featuresRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Project>>> GetProjects()
        {
            return Ok(await _projectRepo.ListAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var spec = new ProjectFullDataSpecification(id);
            return await _projectRepo.GetEntityWithSpec(spec);
        }
    }
}
