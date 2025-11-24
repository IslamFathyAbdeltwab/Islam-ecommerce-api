using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Abstraction.IServices;
using ECommerce.Shared.Common.QueryParameters;
using ECommerce.Shared.Dto_s.Product;
using ECommerce.Shared.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Presentation.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    [Authorize]
    public class ProductController(IServiceManager serviceManager):ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ProductPagination>> GetAllProductAsync([FromQuery]ProductQueryParameter parameters)
        {
            var products=await serviceManager.ProductService.GetAllProductsAsync(parameters);

            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductByIdAsync(int id)
        {
            var products = await serviceManager.ProductService.GetProductByIdAsync(id);

            return Ok(products);
        }
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrandsAsync()
        {
            var Brands =await serviceManager.ProductService.GetAllBrandsAsync();

            return Ok(Brands);
        }
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypesAsync()
        {
            var Types = await serviceManager.ProductService.GetAllTypesAsync();

            return Ok(Types);
        }

    }
}
