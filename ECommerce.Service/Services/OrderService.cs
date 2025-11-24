using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Abstraction.IServices;
using ECommerce.Domain.Contract;
using ECommerce.Domain.Errors;
using ECommerce.Domain.Models.Order;
using ECommerce.Domain.Models.Product;
using ECommerce.Presistence.Model.Identity;
using ECommerce.Service.Specification;
using ECommerce.Shared.Dto_s.Authentication;
using ECommerce.Shared.Dto_s.Order;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ECommerce.Service.Services
{
    public class OrderService(IMapper mapper, IBasketRepository basketRepository, IUnitOfWork unitOfWork) : IOrderService
    {
        public async Task<OrderToReturnDto> CreateOrderAsync(OrderDto order, string email)
        {
            // create order to create it need its member 
            //first address
            var address = mapper.Map<AddressDto, OrderAddress>(order.Address);

            // orderitems

            var basket = await basketRepository.GetBasketAsync(order.BasketId) ?? throw new BasketNotFound(order.BasketId);

            List<OrderItem> orderItems = [];
            var productRepo = unitOfWork.GetRepository<Product, int>();
            foreach (var item in basket.Items)
            {
                var product = await productRepo.GetAsync(item.Id) ?? throw new ProductNotFound(item.Id);
                var orderItem = new OrderItem()
                {
                    Product = new ProductItemOrdered()
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        PictureUrl = product.PictureUrl,
                    },
                    Quantity = item.Qunatity,
                    Price = product.Price

                };
                orderItems.Add(orderItem);

            }

            //deliverymethod

            var DeliveryMethod = await unitOfWork.GetRepository<DeliveryMethod, int>().GetAsync(order.DeliveryMethodId) ??
                throw new DeliveryMethodNotFound(order.DeliveryMethodId);

            // subtotal

            var subtotal = orderItems.Sum(o => o.Price * o.Quantity);
            //total
            //var total = subtotal + DeliveryMethod.Price; inside the order class i calc it so not need to calc it here



            var Order = new Order()
            {
                UserEmail = email,
                Address = address,
                Items = orderItems,
                DeliveryMethod = DeliveryMethod,
                SubTotal = subtotal,
            };

            await unitOfWork.GetRepository<Order, Guid>().AddAsync(Order);
            await unitOfWork.saveChangesAsync();

            return mapper.Map<OrderToReturnDto>(Order);
        }

        public async Task<IEnumerable<OrderToReturnDto>> GetAllOrdersAsync(string email)
        {
            var spec = new OrderSpecification(email);
            var res =await  unitOfWork.GetRepository<Order, Guid>().GetAllWithSpecificationAsync(spec);

            if(res is not null)
            {
              return  mapper.Map<IEnumerable<OrderToReturnDto>>(res);
              
            }
            return null;
        }

        public async Task<IEnumerable<DeliveryMethodDto>> GetDeliveryMethodsAsync()
        {
           var res=await unitOfWork.GetRepository<DeliveryMethod,int>().GetAllAsync();

           if(res is not null)
            {
                return mapper.Map<IEnumerable<DeliveryMethod>,IEnumerable<DeliveryMethodDto>>(res);
            }
            return null;
        }

        public async Task<OrderToReturnDto> GetOrderByIdAsync(Guid id)
        {
            var spec = new OrderSpecification(id);
            var res =await  unitOfWork.GetRepository<Order, Guid>().GetWithSpecificationAsync(spec);

            if(res is not null)
            {
                return mapper.Map<OrderToReturnDto>(res);
            }
            return null;
        }
    }
}
