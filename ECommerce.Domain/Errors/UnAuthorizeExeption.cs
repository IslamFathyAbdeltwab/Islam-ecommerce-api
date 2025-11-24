using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Errors
{
    public class UnAuthorizeExeption(string message= "User UnAuthorize Email or password is wrong") :Exception(message)
    {
    }
}
