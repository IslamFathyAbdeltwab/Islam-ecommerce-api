using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Abstraction.IServices;
using ECommerce.Service.Profiles;
using ECommerce.Service.Services.ServiceManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.Service.Common.RegisterServices
{
    public static class RegisterServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services, WebApplicationBuilder builder)
        {

            services.AddAutoMapper(m =>
            {

                m.AddProfile(new ProductProfile(builder.Configuration));
                m.AddProfile(new BasketProfile());
                m.AddProfile(new AuthenticationProfile());
                m.AddProfile(new OrderProfile(builder.Configuration));


            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    //ValidIssuer = builder.Configuration.GetSection("JwtOptions")["Issure"],
                    ValidateAudience = false,
                    //ValidAudience = builder.Configuration.GetSection("JwtOptions")["Audience"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtOptions")["SecurityKey"])),

                };
            });

            services.AddScoped<IServiceManager, ServiceManager>();
            return services;

        }
    }
}
