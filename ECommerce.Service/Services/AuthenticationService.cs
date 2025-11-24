using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Abstraction.IServices;
using ECommerce.Domain.Contract;
using ECommerce.Domain.Errors;
using ECommerce.Presistence.Model.Identity;
using ECommerce.Shared.Dto_s.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace ECommerce.Service.Services
{
    public class AuthenticationService(UserManager<ApplicationUser> userManager, IConfiguration configuration, IMapper mapper, IAddressRepository addressRepository) : IAuthentecationServices
    {
        public async Task<UserDto> LoginAsync(LoginDto login)
        {
            var user = await userManager.FindByEmailAsync(login.Email) ?? throw new UserNoFoundExeption();
            var ispasswordValid = await userManager.CheckPasswordAsync(user, login.Password);
            if (ispasswordValid)
            {
                return new UserDto()
                {
                    Email = user.Email,
                    Token = await CreateTokenAsync(user),
                    DisplayName = user.DisplayName,
                };
            }
            throw new UnAuthorizeExeption();

        }

        public async Task<UserDto> RegisterAsync(RegisterDto register)
        {
            var user = new ApplicationUser()
            {
                DisplayName = register.DisplayName,
                Email = register.Email,
                PhoneNumber = register.Phone,
                UserName = register.Username,

            };

            var result = await userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
                return new UserDto()
                {
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    Token = await CreateTokenAsync(user)
                };
            }

            var errors = result.Errors.Select(e => e.Description).ToList();
            throw new BadRequestExeption(errors);

        }


        public async Task<bool> CheckEmailAsync(string Email)
        {
            var res = await userManager.FindByEmailAsync(Email);
            if (res is not null)
            {
                return true;
            }

            return false;

        }

        public async Task<UserDto> GetCurrentUser(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user is not null)
            {
                return mapper.Map<UserDto>(user); // must map to usedto
            }
            return null; //here if user not found how user not found must found;
        }
        public async Task<AddressDto> GetCurrentUserAddress(string userid)
        {


            var address = await addressRepository.GetAddressAsync(userid);
            if (address is not null)
            {

                return mapper.Map<AddressDto>(address);
            }
            return null;// this user not have address 


        }


        public async Task<AddressDto> UpdateUserAddress(string email, AddressDto address)
        {
            var user = await userManager.FindByEmailAsync(email);

            if(user is not null)
            {
                var Address = mapper.Map<Address>(address);
                Address.UserId = user.Id;
                var res = await addressRepository.AddAddressAsync(Address);
                return mapper.Map<AddressDto>(res);
            }

            throw new UserNoFoundExeption();



        }
        async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
            {

                new(ClaimTypes.Email,user.Email),
                new(ClaimTypes.Name,user.UserName),
                new(ClaimTypes.NameIdentifier,user.Id),


            };
            var Roles = await userManager.GetRolesAsync(user);

            foreach (var role in Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var secretkey = configuration.GetSection("JwtOptions")["SecurityKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey));

            var Creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: "xyzzz", audience: "xyzzz",
                claims = claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: Creds

                );


            return new JwtSecurityTokenHandler().WriteToken(token);



        }


    }
}
