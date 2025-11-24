using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Dto_s.Authentication
{
    public class UserDto
    {
        public string DisplayName   { get; set; }
        public string Email { get; set; }

        public string Token { get; set; }
    }
}
