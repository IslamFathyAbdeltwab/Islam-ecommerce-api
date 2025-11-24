using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Common.Entity;

namespace ECommerce.Domain.Contract
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity,Tkey> GetRepository<TEntity, Tkey>()
            where TEntity:BaseEntity<Tkey>
            where Tkey:IEquatable<Tkey>;
        
        Task<int> saveChangesAsync();
    }
}
