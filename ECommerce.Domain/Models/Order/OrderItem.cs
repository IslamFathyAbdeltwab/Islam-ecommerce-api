using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Common.Entity;

namespace ECommerce.Domain.Models.Order
{
    public class OrderItem:BaseEntity<int>
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public ProductItemOrdered Product { get; set; } = null!;
    }
}
