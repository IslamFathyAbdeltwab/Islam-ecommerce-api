using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Models.Product;
using ECommerce.Domain.Specification;
using ECommerce.Shared.Common.QueryParameters;

namespace ECommerce.Service.Specification
{
    public class ProductSpecification : BaseSpecification<Product, int>
    {

        public ProductSpecification(ProductQueryParameter param) : base(p => (!param.brandId.HasValue || p.BrandId == param.brandId) && (!param.typeId.HasValue || p.TypeId == param.typeId) && ( string.IsNullOrEmpty(param.search) ||p.Name.ToLower().Contains(param.search.ToLower())))
        {
            AddIncludes();
            if (param.sort is not null)
            {
                switch (param.sort)
                {
                    case "price":
                        orderbyAcending(p => p.Price);
                        break;
                    case "priceDesc":
                        orderbyDescending(p => p.Price);
                        break;
                    default:
                        orderbyAcending(p => p.Name);
                        break;

                        //sortby name;
                }
            }
            //i enforce each request must applay pagination if request not have pagination info so but defult
            Paginated(param.pageIndex*param.pageSize-param.pageSize,param.pageSize);
            
        }

        protected override void AddIncludes()
        {
            base.AddIncludes();
            base.Includes.Add(p => p.Brand);
            base.Includes.Add(p => p.Type);
        }

        public ProductSpecification(int id) : base(p => p.Id == id)
        {
            AddIncludes();
        }
    }
}
