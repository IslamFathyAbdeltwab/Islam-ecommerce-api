using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Presentation.Contexts
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> option) : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);
        }

        public DbSet<Product> products { get; set; }

        public DbSet<ProductType> productsType { get; set; }

        public DbSet<ProductBrand> productBrands { get; set; }
    }
}
