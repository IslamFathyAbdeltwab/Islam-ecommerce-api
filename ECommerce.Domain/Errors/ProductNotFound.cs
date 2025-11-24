using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Errors
{
    public class ProductNotFound(object tkey):NotFoundExeption($"the product with id:{tkey} is not found .")
    {
    }
}
