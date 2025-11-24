using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Common.Entity
{
    public class BaseAuditableEntity<TEntity,Tkey>:BaseEntity<Tkey> where Tkey : IEquatable<Tkey>
     
    {
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public string? LastModifedBy { get; set; }

        public DateTime LastModifedOn { get; set; }
    }
}
