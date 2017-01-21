using Tasklist.DAL.SQL;
using Tasklist.Domain.Contracts;

namespace TaskList.Tests.DAL.SQL
{
    internal static class UnitOfWorkFabric
    {
        public static IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(new DataContext());
        }
    }
}
