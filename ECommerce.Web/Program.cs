
using ECommerce.Domain.Contract;
using ECommerce.Presentation.Contexts;
using ECommerce.Presistence.Common.RegisterPresistence;
using ECommerce.Presistence.Contexts;
using ECommerce.Presistence.IntializeDataBase.Seed;
using ECommerce.Presistence.Model.Identity;
using ECommerce.Service.Common.RegisterServices;
using ECommerce.Shared.Errors;
using ECommerce.Web.Middelware;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();


            builder.Services.AddPresistenceServices(builder);//come from the presistenceservices
            builder.Services.AddServices(builder);// come from service project
          

            #region configure the modelstate to return custom validation errors

            builder.Services.Configure<ApiBehaviorOptions>((option) =>
            {
                option.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState.Where(m => m.Value.Errors.Any())
                                                  .Select(e => new ValidationError()
                                                  {
                                                      Feild = e.Key,
                                                      Errors = e.Value.Errors.Select(e => e.ErrorMessage)
                                                  });
                    
                    var response=new ValidationErrors() { Errors = errors };

                    return new BadRequestObjectResult(response);
                };
            });
            #endregion
            //builder.Services.AddDbContext<StoreDbContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            //});
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            //builder.Services.AddScoped<IDataSeed, DataSeed>();
            var app = builder.Build();

            using var scope=app.Services.CreateScope();
            var objectSeeding=scope.ServiceProvider.GetRequiredService<IDataSeed>();
            objectSeeding.Seed();



            app.UseMiddleware<ExeptionHandelingMiddelware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();


            app.MapControllers();

            app.Run();
        }
    }
}
