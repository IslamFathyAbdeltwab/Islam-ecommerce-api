using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models.Basket
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Qunatity { get; set; }
    }
}
