using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Common.Entity;

namespace ECommerce.Domain.Models.Order
{
    public class Order : BaseAuditableEntity<Order, Guid>
    {
        public string UserEmail { get; set; } = null!;
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;

        public OrderAddress Address { get; set; } = null!;

        public DeliveryMethod DeliveryMethod { get; set; } = null!;
        [ForeignKey(nameof(DeliveryMethod))]
        public int DeliveryMethodId { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending; //default is =0 ===pending

        public ICollection<OrderItem> Items { get; set; } = [];
        public decimal SubTotal { get; set; }
        
        public decimal Total ()=>SubTotal+DeliveryMethod.Price;


    }
}
