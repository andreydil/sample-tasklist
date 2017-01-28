using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tasklist.Domain.Contracts;
using Tasklist.Domain.Contracts.Services;
using Tasklist.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace Tasklist.BLL.Servcies
{
    public class ProjectService: BaseService, IProjectService
    {
        public ProjectService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Task<Project> GetProjectByIdAsync(long id)
        {
            return UnitOfWork.ProjectRepository.GetByIdAsync(id);
        }

        public Task<List<Project>> GetAllProjectsAsync()
        {
            return UnitOfWork.ProjectRepository.GetAllAsync();
        }

        public Task AddProjectAsync(Project project)
        {
            if (project.DueDate < DateTime.Today)
            {
                project.DueDate = DateTime.Today.AddDays(7);
            }
            UnitOfWork.ProjectRepository.Add(project);
            return UnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(long id)
        {
            var project = await GetProjectByIdAsync(id);
            foreach (var task in project.Tasks.ToList())
            {
                UnitOfWork.TaskRepository.Delete(task);
            }
            UnitOfWork.ProjectRepository.Delete(project);
            await UnitOfWork.SaveChangesAsync();
        }

        public Task UpdateProjectAsync(Project project)
        {
            foreach (var task in project.Tasks.Where(t => t.Id != 0).ToList())
            {
                project.Tasks.Remove(task);
                UnitOfWork.TaskRepository.Delete(task);
            }
            foreach (var task in project.Tasks.Where(t => !string.IsNullOrWhiteSpace(t.Name)))
            {
                task.ProjectId = project.Id;
                UnitOfWork.TaskRepository.Add(task);
            }
            UnitOfWork.ProjectRepository.Update(project);
            return UnitOfWork.SaveChangesAsync();
        }
    }
}
