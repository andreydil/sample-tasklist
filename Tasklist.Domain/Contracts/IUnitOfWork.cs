using System.Threading.Tasks;
using Tasklist.Domain.Contracts.Repositories;

namespace Tasklist.Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();

        IProjectRepository ProjectRepository { get; }
        ITaskRepository TaskRepository { get; }
    }
}
