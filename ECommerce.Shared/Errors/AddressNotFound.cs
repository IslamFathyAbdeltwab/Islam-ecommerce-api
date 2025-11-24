using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Errors
{
    public class AddressNotFound(string email):Exception($"the user : {email} have no address")
    {
    }
}
