using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Tasklist.Domain.Contracts.Repositories;
using Tasklist.Domain.Entities;

namespace Tasklist.DAL.SQL.Repositories
{
    public class ProjectRepository : BaseRepository<DataContext, Project>, IProjectRepository
    {
        public ProjectRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public override Task<Project> GetByIdAsync(object id)
        {
            return DbSet.Include(p => p.Tasks).FirstOrDefaultAsync(p => p.Id.Equals((long)id));
        }

        protected override IQueryable<Project> AllQuery()
        {
            return base.AllQuery().Include(p => p.Tasks);
        }

        public Task<List<Project>> GetProjectsByNameAsync(string nameSubstring)
        {
            return AllQuery().Where(p => p.Name.Contains(nameSubstring)).ToListAsync();
        }
    }
}
