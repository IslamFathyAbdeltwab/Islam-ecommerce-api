using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Common.Entity;
using ECommerce.Domain.Models.Product;
using ECommerce.Presentation.Configration.CommonConfigration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.Presistence.Configration.ProductConfigration
{
    public class ProductTypeConfigration:BaseEntityConfiguration<ProductType,int>
    {
        public override void Configure(EntityTypeBuilder<ProductType> builder)
        {
            base.Configure(builder);

            //
            builder.Property(p => p.Name).HasColumnType("varchar(50)");
        }
    }
}
