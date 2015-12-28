
using OkFood.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.Configuration
{
     internal class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        internal CategoryConfiguration()
        {
            ToTable("Category");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Title)
                .HasColumnName("Title")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsRequired();

            Property(x => x.NumberofMoney)
                .HasColumnName("NumberofMoney")
                .HasColumnType("decimal")
                .HasPrecision(19, 2)
                .IsOptional();

            HasMany(x => x.Subcategories)
                .WithRequired(x => x.Category)
                    .WillCascadeOnDelete(true);



        }
    }
}
