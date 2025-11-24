using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Models.Product;
using ECommerce.Presentation.Configration.CommonConfigration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Presistence.Configration.ProductConfigration
{
    public class ProductBrandConfigration:BaseEntityConfiguration<ProductBrand,int>
    {

        public override void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            base.Configure(builder);


            builder.Property(p => p.Name).HasColumnType("varchar(50)");
        }
    }
}
