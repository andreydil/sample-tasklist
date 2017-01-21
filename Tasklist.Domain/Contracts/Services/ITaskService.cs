using System.Threading.Tasks;

namespace Tasklist.Domain.Contracts.Services
{
    public interface ITaskService
    {
        Task AddTaskAsync(Entities.Task task);
        Task DeleteTaskAsync(long id);
        Task UpdateTaskAsync(Entities.Task task);
    }
}
