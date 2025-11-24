using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Domain.Models.Basket;
using ECommerce.Presistence.Model.Identity;
using ECommerce.Shared.Dto_s.Authentication;
using ECommerce.Shared.Dto_s.Basket;

namespace ECommerce.Service.Profiles
{
    internal class AuthenticationProfile : Profile
    {


        public AuthenticationProfile()
        {
            CreateMap<UserDto, ApplicationUser>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();

        }

    }
}
