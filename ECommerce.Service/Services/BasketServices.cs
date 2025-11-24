using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Abstraction.IServices;
using ECommerce.Domain.Contract;
using ECommerce.Domain.Errors;
using ECommerce.Domain.Models.Basket;
using ECommerce.Shared.Dto_s.Basket;

namespace ECommerce.Service.Services
{
    public class BasketServices(IBasketRepository repo,IMapper mapper) : IBasketServices
    {
        public async Task<BasketDto> CreateOrUpdateAsync(BasketDto basket)
        {
            var Basket=mapper.Map<BasketDto,Basket>(basket);
            var returnBasket=  await repo.CreateUpdateBasketAsync(Basket);
            if(returnBasket != null)
                return await GetBasketAsync(returnBasket.Id);
            throw new Exception("some thing went wrong in proccessing");
        }

        public async Task<bool> DeleteBasketAsync(string key)
        {
           return await repo.DeleteBasketAsync(key);
           
        }

        public async Task<BasketDto> GetBasketAsync(string key)
        {
            var basket = await repo.GetBasketAsync(key);

            if(basket is not null)
            {
                return mapper.Map<Basket,BasketDto>(basket);
            }
            throw new BasketNotFound(key);
        }
    }
}
