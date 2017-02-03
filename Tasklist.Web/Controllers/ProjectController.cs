using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Tasklist.Domain.Contracts.Services;
using Tasklist.Domain.Entities;
using Tasklist.Web.Mapping;
using Tasklist.Web.Models;

namespace Tasklist.Web.Controllers
{
    public class ProjectController : ApiController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        
        public async Task<List<ProjectModel>> Get()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return projects.Select(ProjectMapper.Map).ToList();
        }

        public async Task<ProjectModel> Get(long id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            return ProjectMapper.Map(project);
        }

        public async Task<long> Post(ProjectModel project)
        {
            var newProject = new Project
            {
                Name = project.Name,
                Description = project.Description,
            };
            await _projectService.AddProjectAsync(newProject);
            return newProject.Id;
        }

        public async System.Threading.Tasks.Task Put(ProjectModel project)
        {
            var existingProject = await _projectService.GetProjectByIdAsync(project.Id);
            if (existingProject != null)
            {
                existingProject.Name = project.Name;
                existingProject.Description = project.Description;
                var tasks = existingProject.Tasks?.ToList() ?? new List<Domain.Entities.Task>();
                tasks.AddRange(project.Tasks.Select(TaskMapper.Map).ToList());
                existingProject.Tasks = tasks;
                await _projectService.UpdateProjectAsync(existingProject);
            }
        }

        public async System.Threading.Tasks.Task Delete(long id)
        {
            await _projectService.DeleteProjectAsync(id);
        }
    }
}
