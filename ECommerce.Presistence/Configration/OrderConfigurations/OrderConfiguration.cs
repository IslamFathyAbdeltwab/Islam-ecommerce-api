using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Models.Order;
using ECommerce.Presentation.Configration.CommonConfigration;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Presistence.Configration.OrderConfiguration
{
    public class OrderConfiguration:BaseAuditableEntityConfiguration<Order,Guid>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.ToTable("orders");
            builder.Property(o => o.SubTotal).HasColumnType("decimal(8,2)");
            builder.OwnsOne(o => o.Address);
            builder.HasOne(o => o.DeliveryMethod).WithMany().HasForeignKey(o => o.DeliveryMethodId);
        }
    }
}
