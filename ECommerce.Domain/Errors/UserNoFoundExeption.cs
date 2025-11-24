using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Errors
{
    public class UserNoFoundExeption():NotFoundExeption("user not found .Emali or password is not correct")
    {
    }
}
