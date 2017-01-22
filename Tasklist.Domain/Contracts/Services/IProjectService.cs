using System.Collections.Generic;
using System.Threading.Tasks;
using Tasklist.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace Tasklist.Domain.Contracts.Services
{
    public interface IProjectService
    {
        Task<Project> GetProjectByIdAsync(long id);
        Task<List<Project>> GetAllProjectsAsync();
        Task AddProjectAsync(Project project);
        Task DeleteProjectAsync(long id);
        Task UpdateProjectAsync(Project project);
    }
}
