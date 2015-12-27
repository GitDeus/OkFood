using OkFood.Data.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.Configuration
{
    internal class UserConfiguration : EntityTypeConfiguration<User>
    {
        internal UserConfiguration()
        {
            ToTable("User");

            HasKey(x => x.UserId)
                .Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.SecurityStamp)
                .HasColumnName("SecurityStamp")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();
            //Property(x => x.TotalMoney)
            //    .HasColumnName("TotalMoney")
            //    .HasColumnType("decimal")
            //    .HasPrecision(19, 2)
            //    .IsOptional();

            Property(x => x.UserName)
                .HasColumnName("UserName")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .Map(x =>
                {
                    x.ToTable("UserRole");
                    x.MapLeftKey("UserId");
                    x.MapRightKey("RoleId");
                });
             HasMany(x => x.BankCards)
            .WithRequired(x => x.User)
            .HasForeignKey(x => x.UserId);

            HasMany(x => x.Claims)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId);

            HasMany(x => x.Logins)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId);

            HasMany(x => x.Orders)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId);

            HasMany(x => x.Categories)
                .WithRequired(x => x.User);
                
        }
    }
}
