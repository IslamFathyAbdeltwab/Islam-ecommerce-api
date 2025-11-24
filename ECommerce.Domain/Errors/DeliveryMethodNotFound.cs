using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Errors
{
    public class DeliveryMethodNotFound(int ID):NotFoundExeption($"The Delivery Method with Id {ID} is not found")
    {
    }
}
