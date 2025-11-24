using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Abstraction.IServices;
using ECommerce.Shared.Dto_s.Authentication;
using ECommerce.Shared.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthentecationController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
        {
            var userdto = await serviceManager.AuthentecationServices.LoginAsync(login);

            return Ok(userdto);
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto register)
        {
            var userdto = await serviceManager.AuthentecationServices.RegisterAsync(register);
            return Ok(userdto);
        }

        [HttpGet("CheckEmail")]
        [Authorize]
        public async Task<ActionResult<bool>> CheckEmail(string email)
        {
            
            var res = await serviceManager.AuthentecationServices.CheckEmailAsync(email);
            return Ok(res);

        }

        [HttpGet("CurrentUser")]
        [Authorize]
        public async Task<UserDto> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await serviceManager.AuthentecationServices.GetCurrentUser(email);

            return user;
        }
        [HttpGet("Address")]
        [Authorize]
        public async Task<AddressDto> GetCurrentUserAddress()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var addressdto = await serviceManager.AuthentecationServices.GetCurrentUserAddress(id);
            if(addressdto is not null)
            {
              return addressdto;
            }
            throw new AddressNotFound(User.FindFirstValue(ClaimTypes.Email));
            
        }

        [HttpPost("Address")]
        [Authorize]

        public async Task<AddressDto> UpdateCurrentUserAddress(AddressDto address)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var updatedAddress = await serviceManager.AuthentecationServices.UpdateUserAddress(email, address);
            return updatedAddress;
        }


    }
}
