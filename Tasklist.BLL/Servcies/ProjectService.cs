using System;
using System.Collections.Generic;
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
            UnitOfWork.ProjectRepository.Delete(project);
            await UnitOfWork.SaveChangesAsync();
        }

        public Task UpdateProjectAsync(Project project)
        {
            UnitOfWork.ProjectRepository.Update(project);
            return UnitOfWork.SaveChangesAsync();
        }
    }
}
