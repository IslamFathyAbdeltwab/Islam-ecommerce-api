using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Common.Entity;

namespace ECommerce.Domain.Models.Product
{
    public class ProductType:BaseAuditableEntity<ProductType,int>
    {
        public string Name { get; set; } = null!;

        public ICollection<Product> Products { get; set; }= new HashSet<Product>();
    }
}
