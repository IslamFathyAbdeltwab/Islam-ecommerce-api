using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Contract;
using ECommerce.Presentation.Contexts;
using ECommerce.Presistence.Contexts;
using ECommerce.Presistence.IntializeDataBase.Seed;
using ECommerce.Presistence.Model.Identity;
using ECommerce.Presistence.Repository;
using ECommerce.Presistence.UOW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
//using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ECommerce.Presistence.Common.RegisterPresistence
{
    public static class RegisterPresistence
    {
        public static IServiceCollection AddPresistenceServices(this IServiceCollection service,WebApplicationBuilder bulider)
        {

            service.AddScoped<IDataSeed,DataSeed>();

            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped<IBasketRepository, BasketRepository>();
            service.AddScoped<IAddressRepository, AddressRepository>();
            
            service.AddSingleton<IConnectionMultiplexer>((p) =>
            {
                return ConnectionMultiplexer.Connect(bulider.Configuration.GetConnectionString("RedisConnection")!);
            });     
            bulider.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(bulider.Configuration.GetConnectionString("Default"));
            });
            service.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<StoreIdentityDbContext>();

            bulider.Services.AddDbContext<StoreIdentityDbContext>((options) =>
            {
                options.UseSqlServer(bulider.Configuration.GetConnectionString("IdentityConnection"));
            });


            return service;
            
        } 
    }
}
