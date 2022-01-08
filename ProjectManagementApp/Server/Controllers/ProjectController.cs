using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementApp.Server.Data;
using ProjectManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

       static List<Project> projects = new List<Project>
       {
           new Project {Id =1, name = "MarketPlace", description = "test marketplace description", createdAt = new DateTime(), updatedAt = new DateTime(), companyId = "1" },
           new Project {Id =2, name = "Click2Play", description = "test C2P description", createdAt = new DateTime(), updatedAt = new DateTime(), companyId = "1" },
           new Project {Id =3,name = "GeoReach", description = "test reo reach description", createdAt = new DateTime(), updatedAt = new DateTime(), companyId = "1" },
        };

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            return Ok(projects);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectDetails(int id)
        {
            var project = projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
                return NotFound("Project is not found!");

            return Ok(project);

        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(Project project)
        {
            project.Id = projects.Max(h => h.Id + 1);
            projects.Add(project);
            return Ok(projects);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(Project project, int id)
        {
            var dbProject = projects.FirstOrDefault(h => h.Id == id);
            if(dbProject == null)
            {
                return NotFound("Project was not found!");
            }
            var index = projects.IndexOf(dbProject);
            projects[index] = project;
            dbProject = project;
            return Ok(projects);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var dbProject = projects.FirstOrDefault(h => h.Id == id);
            if (dbProject == null)
            {
                return NotFound("Project was not found!");
            }
            projects.Remove(dbProject);
            return Ok(projects);
            
        }
    }
}
