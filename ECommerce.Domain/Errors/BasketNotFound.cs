using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Errors
{
    public class BasketNotFound(string key):NotFoundExeption($"Basket with id : {key} is not found")
    {
    }
}
