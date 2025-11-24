using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Common.Entity;

namespace ECommerce.Domain.Contract
{
    public interface ISpecification<TEntity,Tkey>
        where TEntity:BaseEntity<Tkey>
        where Tkey:IEquatable<Tkey>
    {
        Expression<Func<TEntity,bool>> Criteria { get;  set; }

        List<Expression<Func<TEntity,object>>>   Includes{ get; set; }

        Expression<Func<TEntity,object>> OrderBy { get; set; }

        Expression<Func<TEntity, object>> OrderByDesc { get; set; }
         Expression<Func<TEntity, object>> Name { get; set; } 

        int skip { get; set; }
        int take { get; set; }
        bool IsPaginated { get; set; }




    }
}
