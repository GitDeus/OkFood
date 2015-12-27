using OkFood.Data.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.Configuration
{
     internal class SubcategoryConfiguration : EntityTypeConfiguration<Subcategory>
    {
        internal SubcategoryConfiguration()
        {
            ToTable("Subcategory");

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

            Property(x => x.Value)
                .HasColumnName("Value")
                .HasColumnType("decimal")
                .HasPrecision(19, 2)
                .IsRequired();

            Property(x => x.Date)
                .HasColumnName("Date")
                .HasColumnType("datetime")
                .IsOptional();

            HasRequired(x => x.Category)
                .WithMany(x => x.Subcategories);
                

        }
    }
}
