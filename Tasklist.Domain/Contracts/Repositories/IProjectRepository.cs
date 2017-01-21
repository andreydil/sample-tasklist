using System.Collections.Generic;
using System.Threading.Tasks;
using Tasklist.Domain.Entities;

namespace Tasklist.Domain.Contracts.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<List<Project>> GetProjectsByNameAsync(string nameSubstring);
    }
}
