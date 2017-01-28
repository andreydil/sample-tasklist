using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Tasklist.Domain.Contracts.Repositories;

namespace Tasklist.DAL.SQL.Repositories
{
    public class BaseRepository<TContext, TEntity> : IBaseRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        protected TContext DbContext { get; }
        protected DbSet<TEntity> DbSet { get; set; }

        public BaseRepository(TContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        protected virtual IQueryable<TEntity> AllQuery()
        {
            return DbSet.AsQueryable();
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return AllQuery().ToListAsync();
        }

        public virtual Task<TEntity> GetByIdAsync(object id)
        {
            return DbSet.FindAsync(id);
        }

        public virtual void Add(TEntity obj)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(obj);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(obj);
            }
        }

        public virtual void Update(TEntity obj)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(obj);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(obj);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public async Task Delete(object id)
        {
            var obj = await GetByIdAsync(id);
            if (obj != null)
            {
                Delete(obj);
            }
        }

        public void Delete(TEntity entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }
    }
}
