using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Microsoft.AspNet.Identity;
using OkFood.Data.Identity;
using System;
using OkFood.Data.Repositories;
using OkFood.Domain.Interfaces;
using OkFood.Domain.Model.Entities;
using OkFood.Data.NStore;

namespace OkFood
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager(), new InjectionConstructor("OkFood"));
            container.RegisterType<IUserStore<IdentityUser, Guid>, UserStore>(new TransientLifetimeManager());
            container.RegisterType<IRoleStore<IdentityRole, Guid>>(new TransientLifetimeManager());
            container.RegisterType<IOrderStore<Order, Guid>, OrderStore>(new TransientLifetimeManager());
            container.RegisterType<IDeliveryAddressStore<DeliveryAddress, Guid>, DeliveryAddressStore>(new TransientLifetimeManager());
            

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}