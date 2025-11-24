using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Domain.Models.Product;
using ECommerce.Shared.Dto_s.Product;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Service.Profiles
{
    public class PictureUrlResolver(IConfiguration configuration) : IValueResolver<Product, ProductDto, string>
    {
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
           if(string.IsNullOrEmpty(source.PictureUrl))
            {
                return null;
            }
            else
            {
                var url = $"{configuration.GetSection("Urls")["BaseUrl"]}/{source.PictureUrl}";
                return url;
            }
        }
    }
}
