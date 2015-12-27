using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using OkFood.Data.Model.Interfaces;
using Microsoft.AspNet.Identity;
using OkFood.Data.Identity;
using System;
using OkFood.Data.Repositories;

namespace OkFood
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager(), new InjectionConstructor("OkFood"));
            container.RegisterType<IUserStore<IdentityUser, Guid>, UserStore>(new TransientLifetimeManager());
            container.RegisterType<RoleStore>(new TransientLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}