
using OkFood.Data.Configuration;
using OkFood.Domain.Model.Entities;
using System;
using System.Data.Entity;

namespace OkFood.Data.Context
{
    public interface IDataContext : IDisposable
    {

    }
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            
        }
        public IDbSet<Subcategory> DbSubcategories { get; set; }
        public IDbSet<Category> DbCategories { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<BankCard> BankCards { get; set; }
        public IDbSet<DeliveryAddress> DbDeliveryAddress { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<ExternalLogin> Logins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ExternalLoginConfiguration());
            modelBuilder.Configurations.Add(new ClaimConfiguration());
            modelBuilder.Configurations.Add(new SubcategoryConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());

            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new BankCardConfiguration());
            modelBuilder.Configurations.Add(new DeliveryAddressConfiguration());
        }
    }
}
