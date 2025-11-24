using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Domain.Models.Basket;
using ECommerce.Domain.Models.Product;
using ECommerce.Shared.Dto_s.Basket;
using ECommerce.Shared.Dto_s.Product;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Service.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile(IConfiguration configuration)
        {
            CreateMap<Product,ProductDto>()
                .ForMember(dest=>dest.PictureUrl,option=>option.MapFrom(new PictureUrlResolver(configuration)))
                .ReverseMap();
            CreateMap<ProductType,TypeDto>().ReverseMap();
            CreateMap<ProductBrand, BrandDto>().ReverseMap();
           

        }
    }
}
