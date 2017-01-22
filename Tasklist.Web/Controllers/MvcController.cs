using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Mvc;
using Tasklist.Domain.Contracts.Services;
using Tasklist.Domain.Entities;
using Tasklist.Web.Mapping;
using Tasklist.Web.Models;

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
            //TODO: validation
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
        public async Task<ActionResult> Delete(long id)
        {
            await _projectService.DeleteProjectAsync(id);
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}