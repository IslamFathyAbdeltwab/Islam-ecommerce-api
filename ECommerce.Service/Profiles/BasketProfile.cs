using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Domain.Models.Basket;
using ECommerce.Shared.Dto_s.Basket;

namespace ECommerce.Service.Profiles
{
    public class BasketProfile : Profile
    {

        public BasketProfile()
        {
            CreateMap<Basket, BasketDto>().ReverseMap();
            CreateMap<BasketItemDto,BasketItem>().ReverseMap();
        }
    }
}
