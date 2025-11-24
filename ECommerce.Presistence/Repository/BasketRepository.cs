using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ECommerce.Domain.Contract;
using ECommerce.Domain.Models.Basket;
using ECommerce.Shared.Errors;
using StackExchange.Redis;

namespace ECommerce.Presistence.Repository
{
    public class BasketRepository(IConnectionMultiplexer connectionMultiplexer) : IBasketRepository
    {
        public IDatabase database = connectionMultiplexer.GetDatabase();
        public async Task<Basket> GetBasketAsync(string key)
        {
            var res = await database.StringGetAsync(key);
            
            if(res.HasValue)
            {

               var  Basket = JsonSerializer.Deserialize<Basket>(res);
               return Basket;
            }
            return null;

        }
        public async Task<Basket> CreateUpdateBasketAsync(Basket basket, TimeSpan? timeToLive = null)
        {
            RedisValue jsonBasket=default;
            if(basket is not null)
            {
                 jsonBasket=JsonSerializer.Serialize(basket);
            }
            var res = await database.StringSetAsync(basket.Id, jsonBasket, timeToLive ?? TimeSpan.FromHours(5));

            Basket returnedBaskect=null;
            if (res)
            {
               returnedBaskect=await this.GetBasketAsync(basket.Id);
            }

            return returnedBaskect;

            
        }

        public async Task<bool> DeleteBasketAsync(string key)
        {
            var res = await database.KeyDeleteAsync(key);
            return true;

        }


    }
}
