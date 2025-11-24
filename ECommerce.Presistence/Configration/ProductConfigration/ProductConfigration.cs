using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Models.Product;
using ECommerce.Presentation.Configration.CommonConfigration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Presistence.Configration.ProductConfiguration
{
    public class ProductConfigration:BaseAuditableEntityConfiguration<Product,int>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Price).HasColumnType("decimal(10,3)");

            builder.HasOne(p=>p.Brand)
                    .WithMany(B=>B.Products)
                    .HasForeignKey(p=>p.BrandId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Type)
                   .WithMany(T => T.Products)
                   .HasForeignKey(p => p.TypeId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
