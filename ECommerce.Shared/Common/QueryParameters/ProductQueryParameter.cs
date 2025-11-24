using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Shared.Dto_s.Product;

namespace ECommerce.Shared.Common.QueryParameters
{
    public class ProductQueryParameter
    {
        const int maxSixe = 5;
        const int defultIndex = 1;
        public int? brandId { get; set; }
        public int? typeId { get; set; }

        public string? sort { get; set; }
        public string? search { get; set; }

        #region Pagination
        int PageSize=maxSixe;
        public int pageSize { get { return PageSize; } set { PageSize = value > maxSixe ? maxSixe : value; } } 
        public int pageIndex { get; set; } = defultIndex;
        public int totalCount { get; set; }


        #endregion
    }
}
