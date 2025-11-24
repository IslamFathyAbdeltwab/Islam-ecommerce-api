using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Shared.Dto_s.Authentication;

namespace ECommerce.Abstraction.IServices
{
    public interface IAuthentecationServices
    {
        Task<UserDto> LoginAsync(LoginDto login);
        Task<UserDto> RegisterAsync(RegisterDto register);
        Task<bool> CheckEmailAsync(string Email);
        Task<UserDto> GetCurrentUser(string Email);
        Task<AddressDto> GetCurrentUserAddress(string Email);
        Task<AddressDto> UpdateUserAddress(string email, AddressDto address);
    }
}
