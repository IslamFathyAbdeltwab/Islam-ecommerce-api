using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Abstraction.IServices;
using ECommerce.Shared.Dto_s.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController(IServiceManager serviceManager):ControllerBase
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<OrderToReturnDto>> CreateOrder(OrderDto order)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var res =await  serviceManager.OrderService.CreateOrderAsync(order,email);

            return Ok(res);
        }
        [HttpGet("Order")]
        public async Task<ActionResult<IEnumerable<DeliveryMethodDto>>> GetDeliveryMethods()
        {
            var DMs = await serviceManager.OrderService.GetDeliveryMethodsAsync();

            return Ok(DMs);
        }
        [HttpGet("AllOrders")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<OrderToReturnDto>>> GetOrdersForCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var orders =await  serviceManager.OrderService.GetAllOrdersAsync(email);
            return Ok(orders);
        }
        [HttpGet]
        [Authorize]
        
        public async Task<ActionResult<IEnumerable<OrderToReturnDto>>> GetOrdersForUser(Guid id)
        {
          
            var orders = await serviceManager.OrderService.GetOrderByIdAsync(id);
            return Ok(orders);
        }





    }
}
