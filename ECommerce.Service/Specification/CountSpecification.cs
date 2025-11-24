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
    internal class CountSpecification:BaseSpecification<Product,int>
    {
        public CountSpecification(ProductQueryParameter param):base(p => (!param.brandId.HasValue || p.BrandId == param.brandId) && (!param.typeId.HasValue || p.TypeId == param.typeId) && (string.IsNullOrEmpty(param.search) || p.Name.ToLower().Contains(param.search.ToLower())))
        {

        }
    }
}
