using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tasklist.Domain.Contracts.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        void Add(T obj);
        void Update(T obj);
        void Delete(T entity);
    }
}
