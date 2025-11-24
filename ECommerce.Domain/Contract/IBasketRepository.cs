using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Models.Basket;

namespace ECommerce.Domain.Contract
{
    public interface IBasketRepository
    {
        // name of the methods  good to be without the bascket becouse it by convension inside the ibascketrepoisitory
        public Task<Basket> GetBasketAsync(string key);
        public Task<Basket> CreateUpdateBasketAsync(Basket basket, TimeSpan? timeToLinv = null);

        public Task<bool> DeleteBasketAsync(string key);

    }
}
