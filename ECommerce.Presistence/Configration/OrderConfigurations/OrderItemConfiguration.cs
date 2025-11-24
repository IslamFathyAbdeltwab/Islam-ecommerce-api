using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Models.Order;
using ECommerce.Presentation.Configration.CommonConfigration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Presistence.Configration.OrderConfiguration
{
    public class OrderItemConfiguration:BaseEntityConfiguration<OrderItem,int>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            base.Configure(builder);

            builder.ToTable("OrderItems");
            builder.Property(o => o.Price).HasColumnType("decimal(8,2)");
            builder.OwnsOne(o => o.Product);
        }
    }
}
