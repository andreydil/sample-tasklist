using Tasklist.Domain.Contracts.Repositories;
using Task = Tasklist.Domain.Entities.Task;

namespace Tasklist.DAL.SQL.Repositories
{
    public class TaskRepository:BaseRepository<DataContext,Task>, ITaskRepository
    {
        public TaskRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
