using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Abstraction.IServices;
using ECommerce.Domain.Contract;
using ECommerce.Presistence.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Service.Services.ServiceManager
{
    public class ServiceManager(IUnitOfWork unitofwork, IMapper mapper, IBasketRepository basketRepository, UserManager<ApplicationUser> usermanager,IConfiguration configuration,IAddressRepository addressRepository) : IServiceManager
    {
        Lazy<IProductService> _productService => new Lazy<IProductService>(() => new ProductServices(unitofwork, mapper));
        public IProductService ProductService => _productService.Value;

        Lazy<IBasketServices> _BasketServices => new Lazy<IBasketServices>(() => new BasketServices(basketRepository, mapper));
        public IBasketServices BasketServices => _BasketServices.Value;
       
        
        Lazy<IAuthentecationServices> _AuthenticationService => new Lazy<IAuthentecationServices>(() => new AuthenticationService(usermanager, configuration,mapper,addressRepository));     
        public IAuthentecationServices AuthentecationServices => _AuthenticationService.Value;
        Lazy<IOrderService> _orderService => new Lazy<IOrderService>(() => new OrderService(mapper,basketRepository,unitofwork));

        public IOrderService OrderService => _orderService.Value;
    }
}
