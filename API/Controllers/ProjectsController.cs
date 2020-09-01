using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
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

        public ProjectsController(IGenericRepository<Project> projectRepo, IGenericRepository<Feature> featuresRepo)
        {
            _projectRepo = projectRepo;
            _featuresRepo = featuresRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Project>>> GetProjects()
        {
            var spec = new ProjectFullDataSpecification();
            return Ok(await _projectRepo.ListAsync(spec));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var spec = new ProjectFullDataSpecification(id);
            var project = await _projectRepo.GetEntityWithSpec(spec);

            if (project == null) return NotFound(new ApiResponse(404));

            return project;
        }
    }
}
