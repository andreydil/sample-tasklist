using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Tasklist.Domain.Contracts.Services;
using Tasklist.Domain.Entities;
using Tasklist.Web.Mapping;
using Tasklist.Web.Models;
using WebGrease.Css.Extensions;
using Task = Tasklist.Domain.Entities.Task;

namespace Tasklist.Web.Controllers
{
    public class MvcController : Controller
    {
        private readonly IProjectService _projectService;

        public MvcController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<ActionResult> Index()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            var model = new ProjectListVM
            {
                Projects = projects.Select(ProjectMapper.Map).ToList()
            };
            return View(model);
        }

        public ActionResult Add()
        {
            return View(new ProjectModel());
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProjectModel project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }
            var newProject = new Project {
                Name = project.Name,
                Description = project.Description,
            };
            await _projectService.AddProjectAsync(newProject);
            return RedirectToAction("Edit", new { id = newProject.Id });
        }

        public async Task<ActionResult> Edit(long id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            var model = ProjectMapper.Map(project);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProjectModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var project = await _projectService.GetProjectByIdAsync(model.Id);
            if (project != null)
            {
                project.Name = model.Name;
                project.Description = model.Description;
                var tasks = project.Tasks?.ToList() ?? new List<Task>();
                tasks.AddRange(model.Tasks.Select(TaskMapper.Map).ToList());
                project.Tasks = tasks;
                await _projectService.UpdateProjectAsync(project);
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            await _projectService.DeleteProjectAsync(id);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}