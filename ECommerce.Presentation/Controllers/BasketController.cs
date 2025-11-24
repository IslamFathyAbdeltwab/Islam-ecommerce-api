using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Abstraction.IServices;
using ECommerce.Shared.Dto_s.Basket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    [Authorize]
    public class BasketController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BasketDto>> GetBasket(string key)
        {
             var basket =await serviceManager.BasketServices.GetBasketAsync(key);

            return Ok(basket);
            
        }

        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateUpdateBasket(BasketDto basket) 
        {
            var returnBasket= await serviceManager.BasketServices.CreateOrUpdateAsync(basket);

            return Ok(returnBasket);
        }

        [HttpDelete("{key}")]
        public async Task<ActionResult<bool>> DeleteBasket(string key)
        {
            return await serviceManager.BasketServices.DeleteBasketAsync(key);
        }

    }
}
