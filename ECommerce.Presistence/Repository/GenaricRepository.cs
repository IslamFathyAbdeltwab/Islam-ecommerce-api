using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Common.Entity;
using ECommerce.Domain.Contract;
using ECommerce.Domain.Specification;
using ECommerce.Presentation.Contexts;
using ECommerce.Presistence.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ECommerce.Presistence.Repository
{
    public class GenaricRepository<TEntity, Tkey> : IGenericRepository<TEntity, Tkey>
        where TEntity : BaseEntity<Tkey>
        where Tkey:IEquatable<Tkey>
    {
        public StoreDbContext Context { get; }

        public GenaricRepository(StoreDbContext context)
        {
            Context = context;
        }

        //public IEnumerable<TEntity> GetAll(bool withNoTracking =false)
        //{
        //    if (withNoTracking) return Context.Set<TEntity>().ToList();
        //    return Context.Set<TEntity>().AsNoTracking().ToList();
        //}
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool withNoTracking = false)
        {
            if (withNoTracking) return await Context.Set<TEntity>().ToListAsync();
            return await Context.Set<TEntity>().AsNoTracking().ToListAsync();

        }
       
        //public IEnumerable<TEntity> GetAllWithSpecification(ISpecification<TEntity,Tkey>spec,bool withNoTracking = false)
        //{
        //   var query= SpecificationEvaluater.GetQuery(Context.Set<TEntity>(), spec);
        //    if (withNoTracking) return query.ToList();
        //    return query.AsNoTracking().ToList();
        //}
        public async Task<IEnumerable<TEntity>> GetAllWithSpecificationAsync(ISpecification<TEntity, Tkey> spec, bool withNoTracking = false)
        {
            var query = SpecificationEvaluater.GetQuery(Context.Set<TEntity>(), spec);
            if (withNoTracking) return await query.ToListAsync();
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            if (id > 0)
            {
                return await Context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id.Equals(id));
            }
            else return null;
        }
        public async Task<TEntity> GetWithSpecificationAsync( ISpecification<TEntity, Tkey> spec)
        {
            var query = SpecificationEvaluater.GetQuery<TEntity, Tkey>(Context.Set<TEntity>(), spec);

            var entity=await query.FirstOrDefaultAsync();

            return entity;
        }

        public async Task AddAsync(TEntity entity)
        {
          if(entity is not null)
            {
               await Context.Set<TEntity>().AddAsync(entity);
            }
        }

        public void Delete(int id)
        {
            if(id>0)
            {
                TEntity entity = Context.Set<TEntity>().FirstOrDefault(e => e.Id.Equals(id));
                if(entity != null)
                {
                Context.Set<TEntity>().Remove(entity);

                }
            }
        }

        public void Update(TEntity entity)
        {
            if(entity is not null)
            {
                Context.Set<TEntity>().Update(entity);
            }
        }

        public Task<int> GetCountWithSpecificationAsync(BaseSpecification<TEntity, Tkey> spec)
        {
            var query=SpecificationEvaluater.GetQuery(Context.Set<TEntity>(), spec);

            return query.CountAsync();
        }
    }
}
