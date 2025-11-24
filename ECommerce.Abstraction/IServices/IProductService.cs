using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Shared.Common.QueryParameters;
using ECommerce.Shared.Dto_s.Product;
using ECommerce.Shared.Pagination;

namespace ECommerce.Abstraction.IServices
{
    public interface IProductService
    {
        Task<ProductPagination> GetAllProductsAsync(ProductQueryParameter parameters);
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();

      

        Task<IEnumerable<TypeDto>> GetAllTypesAsync();
       Task<ProductDto> GetProductByIdAsync(int id);
    }
}
