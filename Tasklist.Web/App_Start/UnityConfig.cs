using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Tasklist.BLL.Servcies;
using Tasklist.DAL.SQL;
using Tasklist.Domain.Contracts;
using Tasklist.Domain.Contracts.Services;
using Unity.Mvc5;

namespace Tasklist.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IProjectService, ProjectService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}