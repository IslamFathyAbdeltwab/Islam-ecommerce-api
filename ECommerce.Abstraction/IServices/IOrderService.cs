using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Shared.Dto_s.Order;

namespace ECommerce.Abstraction.IServices
{
    public interface IOrderService
    {
        Task<OrderToReturnDto> CreateOrderAsync(OrderDto order,string email);

        Task<IEnumerable<DeliveryMethodDto>> GetDeliveryMethodsAsync();

        Task<IEnumerable<OrderToReturnDto>> GetAllOrdersAsync (string email);

        Task<OrderToReturnDto> GetOrderByIdAsync(Guid id);
    }
}
