
using OkFood.Data.Configuration;
using OkFood.Domain.Model.Entities;
using System.Data.Entity;

namespace OkFood.Data.Context
{
    internal class DataContext : DbContext
    {
        internal DataContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            
        }
        internal IDbSet<Subcategory> DbSubcategories { get; set; }
        internal IDbSet<Category> DbCategories { get; set; }
        internal IDbSet<User> Users { get; set; }
        internal IDbSet<Order> Orders { get; set; }
        internal IDbSet<BankCard> BankCards { get; set; }
        internal IDbSet<DeliveryAddress> DbDeliveryAddress { get; set; }
        internal IDbSet<Role> Roles { get; set; }
        internal IDbSet<ExternalLogin> Logins { get; set; }

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
