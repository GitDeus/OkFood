using OkFood.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.Configuration
{
    internal class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        internal OrderConfiguration()
        {
            ToTable("Order");

            HasKey(x => x.OrderId)
                .Property(x => x.OrderId)
                .HasColumnName("OrderId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.Title)
                .HasColumnName("Title")
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            //HasMany(x => x.DeliveryAddress)
            //    .WithRequired(x => x.Order)
            //    .HasForeignKey(x => x.OrderId);
            //HasMany(x => x.Roles)
            //    .WithMany(x => x.Users)
            //    .Map(x =>
            //    {
            //        x.ToTable("UserRole");
            //        x.MapLeftKey("UserId");
            //        x.MapRightKey("RoleId");
            //    });



        }
    }
}
