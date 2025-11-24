using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Shared.Dto_s.Product;

namespace ECommerce.Shared.Pagination
{
    public class ProductPagination
    {
      public int pageIndex { get; set; }
      public int pageSize { get; set; }
      public int totalCount { get; set; }

      public IEnumerable<ProductDto> Products { get; set; }
    }
}
