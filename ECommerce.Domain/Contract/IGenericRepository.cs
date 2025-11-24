using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Common.Entity;
using ECommerce.Domain.Specification;

namespace ECommerce.Domain.Contract
{
    public interface IGenericRepository<TEntity, Tkey>
        where TEntity : BaseEntity<Tkey>
        where Tkey : IEquatable<Tkey>
    {
        //IEnumerable<TEntity> GetAll(bool withNoTracking=false);
        Task<IEnumerable<TEntity>> GetAllAsync(bool withNoTracking = false);

        Task<IEnumerable<TEntity>> GetAllWithSpecificationAsync(ISpecification<TEntity, Tkey> spec, bool withNoTracking = false);
        Task<int> GetCountWithSpecificationAsync(BaseSpecification<TEntity, Tkey> spec);

        Task<TEntity> GetAsync(int id);
        Task<TEntity> GetWithSpecificationAsync( ISpecification<TEntity, Tkey> spec);


        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
