using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Dto_s.Basket
{
    public class BasketItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string PictureUrl { get; set; }

        [Range(1,double.MaxValue)]
        public decimal Price { get; set; }
        public int Qunatity { get; set; }
    }
}
