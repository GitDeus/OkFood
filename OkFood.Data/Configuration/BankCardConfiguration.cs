using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using OkFood.Domain.Model.Entities;

namespace OkFood.Data.Configuration
{
    internal class BankCardConfiguration : EntityTypeConfiguration<BankCard>
    {
        internal BankCardConfiguration()
        {
            ToTable("BankCard");

            HasKey(x => x.BankCardId)
                .Property(x => x.BankCardId)
                .HasColumnName("BankCardId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.BankCardNumber)
                .HasColumnName("BankCardNumber")
                .HasColumnType("decimal")
                .HasPrecision(19, 2)
                .IsRequired();

            Property(x => x.Currency)
                .HasColumnName("Currency")
                .HasColumnType("nvarchar")
                .HasMaxLength(32)
                .IsOptional();

            //HasMany(x => x.Roles)
            //    .WithMany(x => x.Users)
            //    .Map(x =>
            //    {
            //        x.ToTable("UserRole");
            //        x.MapLeftKey("UserId");
            //        x.MapRightKey("RoleId");
            //    });


            //HasMany(x => x.User)
            //    .WithRequired(x => x.User);
        }
    }
}
