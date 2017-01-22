using Tasklist.Domain.Contracts;

namespace Tasklist.BLL.Servcies
{
    public class BaseService
    {
        protected readonly IUnitOfWork UnitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
