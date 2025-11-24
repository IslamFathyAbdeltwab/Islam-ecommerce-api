using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Common.Entity;
using ECommerce.Domain.Contract;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Presistence.Helpers
{
    public static  class SpecificationEvaluater
    {
        public static IQueryable<TEntity> GetQuery<TEntity,Tkey>(IQueryable<TEntity> BaseQuery,ISpecification<TEntity,Tkey> spec)
            where TEntity : BaseEntity<Tkey>
            where Tkey: IEquatable<Tkey>
        {
            var query=BaseQuery;
            if(spec.Criteria is not null)
            {
                query=query.Where(spec.Criteria);
            }
            if(spec.Includes is not null && spec.Includes.Any())
            {
                query = spec.Includes.Aggregate(query,(currentQuery,Expression)=>currentQuery.Include(Expression));          
            }
            if(spec.OrderBy is not null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            else if(spec.OrderByDesc is not null)
            {
                query=query.OrderByDescending(spec.OrderByDesc);
            }
            if (spec.IsPaginated)
            {
                query=query.Skip(spec.skip).Take(spec.take);
            }
            return query;
        }
    }
}
