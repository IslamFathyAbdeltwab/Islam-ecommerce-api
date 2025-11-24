using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Abstraction.IServices;
using ECommerce.Domain.Contract;
using ECommerce.Domain.Errors;
using ECommerce.Domain.Models.Product;
using ECommerce.Service.Specification;
using ECommerce.Shared.Common.QueryParameters;
using ECommerce.Shared.Dto_s.Product;
using ECommerce.Shared.Pagination;

namespace ECommerce.Service.Services
{
    public class ProductServices(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {
        // dont forget to register the mapper package to Di container
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            IEnumerable<ProductBrand> brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            return mapper.Map<IEnumerable<BrandDto>>(brands);
        }
         
        public async Task<ProductPagination> GetAllProductsAsync(ProductQueryParameter parameters)
        {
            var spec = new ProductSpecification(parameters);
            IEnumerable<Product> products = await unitOfWork.GetRepository<Product, int>().GetAllWithSpecificationAsync(spec);
            if(products is not null)
            {

            var result= mapper.Map<IEnumerable<ProductDto>>(products);  
            var countSpec = new CountSpecification(parameters);
            var count = await unitOfWork.GetRepository<Product, int>().GetCountWithSpecificationAsync(countSpec);
           
            return new ProductPagination() { pageIndex=parameters.pageIndex,pageSize=products.Count(),totalCount=count,Products=result};
            }

            return null;
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            IEnumerable<ProductType> types=await unitOfWork.GetRepository<ProductType,int>().GetAllAsync();
            return mapper.Map<IEnumerable<TypeDto>>(types);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            if (id < 0) return null;
            var spec = new ProductSpecification(id);

            Product p= await unitOfWork.GetRepository<Product,int>().GetWithSpecificationAsync(spec);
            if(p is null)
            {
                throw new ProductNotFound(id);
            }
            return mapper.Map<ProductDto>(p);
        }

        
    }
}
