using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Abstraction.IServices
{
    public interface IServiceManager
    {
        IProductService ProductService { get; } 
        IBasketServices BasketServices { get; }//to prevent anyone have reference to set the prop

        IAuthentecationServices AuthentecationServices { get; }

        IOrderService OrderService { get; }
    }
}
