using OkFood.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.Configuration
{
    internal class DeliveryAddressConfiguration : EntityTypeConfiguration<DeliveryAddress>
    {
        internal DeliveryAddressConfiguration()
        {
            ToTable("DeliveryAddress");

            HasKey(x => x.DeliveryAdressId)
                .Property(x => x.DeliveryAdressId)
                .HasColumnName("DeliveryAdressId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.Comment)
                .HasColumnName("Title")
                .HasColumnType("nvarchar")
                .HasMaxLength(1024)
                .IsOptional();
            Property(x => x.City)
                .HasColumnName("City")
                .HasColumnType("nvarchar")
                .HasMaxLength(64)
                .IsOptional();
            Property(x => x.District)
                .HasColumnName("District")
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            Property(x => x.Street)
                .HasColumnName("Street")
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            Property(x => x.Housing)
                .HasColumnName("Housing")
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            Property(x => x.House)
                .HasColumnName("House")
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsOptional();
            Property(x => x.Number)
                .HasColumnName("Number")
                .HasColumnType("int")
                .IsOptional();

        }
    }
}
