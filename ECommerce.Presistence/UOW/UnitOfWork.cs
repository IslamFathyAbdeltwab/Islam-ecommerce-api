using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Common.Entity;
using ECommerce.Domain.Contract;
using ECommerce.Presentation.Contexts;
using ECommerce.Presistence.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ECommerce.Presistence.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// i use dictionary with getrepository function instead of using lazy intialization 
        /// </summary>
        Dictionary<string, object> Repos;
        public StoreDbContext Context { get; }
      
        public UnitOfWork(StoreDbContext context)
        {
            Context = context;
            Repos= new Dictionary<string, object>();
        }
        public IGenericRepository<TEntity,Tkey> GetRepository<TEntity, Tkey>()
            where TEntity : BaseEntity<Tkey>
            where Tkey : IEquatable<Tkey>
        {
            var name=typeof(TEntity).Name;

            if(Repos.ContainsKey(name))
            {
                return (IGenericRepository<TEntity,Tkey>)Repos[name];
            }
            var obj=new GenaricRepository<TEntity,Tkey>(Context);
            Repos[name] = obj;
            return obj;

        }
        public async  Task<int> saveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
