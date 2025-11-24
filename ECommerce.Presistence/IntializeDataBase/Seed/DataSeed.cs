using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using ECommerce.Domain.Contract;
using ECommerce.Domain.Models.Product;
using ECommerce.Presentation.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Presistence.IntializeDataBase.Seed
{
    public class DataSeed:IDataSeed
    {
        public StoreDbContext Context { get; }
        public DataSeed(StoreDbContext context)
        {
            Context = context;
        }

        public void Seed()
        {
            if(Context.Database.GetPendingMigrations().Any())
            {
                Context.Database.Migrate();
            }

          
            if (!Context.productBrands.Any())
            {
                // why presentation not presistence
                var data = File.ReadAllText("D:\\courses\\back End\\route\\assignments route\\test\\ECommerce\\ECommerce.Presentation\\IntializeDataBase\\Data\\brands.json");

                var result = JsonSerializer.Deserialize<IEnumerable<ProductBrand>>(data);

                if (result != null)
                {
                    Context.productBrands.AddRange(result);
                }
                Context.SaveChanges();

            }
            if (!Context.productsType.Any())
            {
                // why presentation not presistence
                var data = File.ReadAllText("D:\\courses\\back End\\route\\assignments route\\test\\ECommerce\\ECommerce.Presentation\\IntializeDataBase\\Data\\types.json");

                var result = JsonSerializer.Deserialize<IEnumerable<ProductType>>(data);

                if (result != null)
                {
                    Context.productsType.AddRange(result);
                }
                Context.SaveChanges();

            }
            if (!Context.products.Any())
            {
                // why presentation not presistence
                var data = File.ReadAllText("D:\\courses\\back End\\route\\assignments route\\test\\ECommerce\\ECommerce.Presentation\\IntializeDataBase\\Data\\products.json");

                var result = JsonSerializer.Deserialize<IEnumerable<Product>>(data);

                if (result != null)
                {
                    Context.products.AddRange(result);
                }

            }

            Context.SaveChanges();
        }
    }
}
