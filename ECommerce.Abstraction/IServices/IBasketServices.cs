using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Shared.Dto_s.Basket;

namespace ECommerce.Abstraction.IServices
{
    public interface IBasketServices
    {
        Task<BasketDto> GetBasketAsync(string key);

        Task<BasketDto> CreateOrUpdateAsync(BasketDto basket);

        Task<bool> DeleteBasketAsync(string key);


    }
}
