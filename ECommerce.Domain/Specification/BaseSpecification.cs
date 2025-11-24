using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Common.Entity;
using ECommerce.Domain.Contract;

namespace ECommerce.Domain.Specification
{
    public class BaseSpecification<TEntity, Tkey> : ISpecification<TEntity, Tkey>
        where TEntity : BaseEntity<Tkey>
        where Tkey : IEquatable<Tkey>
    {
        public Expression<Func<TEntity, bool>> Criteria { get; set; } = null;
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = new();
        public Expression<Func<TEntity, object>> OrderBy { get; set; } = null;
        public Expression<Func<TEntity, object>> OrderByDesc { get; set; } = null;
        public Expression<Func<TEntity, object>> Name { get; set; } = null;
        public int skip { get; set; }
        public int take { get; set; }
        public bool IsPaginated { get; set; }

        public BaseSpecification(Expression<Func<TEntity, bool>> criteriaExpression)
        {
            Criteria = criteriaExpression;
        }

        public BaseSpecification()
        {

        }

        protected virtual void orderbyAcending(Expression<Func<TEntity, object>> expression) => OrderBy = expression;

        protected void orderbyDescending(Expression<Func<TEntity, object>> expression) => OrderByDesc = expression;
        protected virtual void AddIncludes() { }

        protected virtual void Paginated(int skip, int take)
        {
            this.skip = skip;
            this.take = take;
            IsPaginated = true;
        }

    }
}
