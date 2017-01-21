using System.Threading.Tasks;
using Tasklist.DAL.SQL.Repositories;
using Tasklist.Domain.Contracts;
using Tasklist.Domain.Contracts.Repositories;

namespace Tasklist.DAL.SQL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public Task SaveChangesAsync()
        {
            return _dataContext.SaveChangesAsync();
        }

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private IProjectRepository _projectRepository;

        public IProjectRepository ProjectRepository
        {
            get
            {
                _projectRepository = _projectRepository ?? new ProjectRepository(_dataContext);
                return _projectRepository;
            }
        }

        private ITaskRepository _taskRepository;

        public ITaskRepository TaskRepository
        {
            get
            {
                _taskRepository = _taskRepository ?? new TaskRepository(_dataContext);
                return _taskRepository;
            }
        }
    }
}
