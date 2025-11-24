using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Domain.Models.Order;
using ECommerce.Presistence.Model.Identity;
using ECommerce.Shared.Dto_s.Authentication;
using ECommerce.Shared.Dto_s.Order;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ECommerce.Service.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile(IConfiguration configuration)
        {
            CreateMap<Order,OrderToReturnDto>()
                .ForMember(d=>d.DeliveryMethod,options=>options.MapFrom(src=>src.DeliveryMethod.ShortName)).ReverseMap();
            CreateMap<AddressDto, OrderAddress>().ReverseMap();
            CreateMap<OrderItem,OrderItemDto>()
                .ForMember(d=>d.ProductName,option=>option.MapFrom(src=>src.Product.ProductName))
                .ForMember(d => d.PictureUrl, option => option.MapFrom(new OrderPictureUrlResolver(configuration))).ReverseMap();

            CreateMap<DeliveryMethod, DeliveryMethodDto>().ReverseMap();

        }
    }
}
