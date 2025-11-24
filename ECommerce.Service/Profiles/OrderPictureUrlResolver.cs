using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Domain.Models.Order;
using ECommerce.Domain.Models.Product;
using ECommerce.Shared.Dto_s.Order;
using ECommerce.Shared.Dto_s.Product;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Service.Profiles
{
    public class OrderPictureUrlResolver(IConfiguration configuration) : IValueResolver<OrderItem,OrderItemDto, string>
    {
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.Product.PictureUrl))
            {
                return null;
            }
            else
            {
                var url = $"{configuration.GetSection("Urls")["BaseUrl"]}/{source.Product.PictureUrl}";
                return url;
            }
        }
    }
}
