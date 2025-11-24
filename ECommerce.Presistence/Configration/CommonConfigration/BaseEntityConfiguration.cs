using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Common.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Presentation.Configration.CommonConfigration
{
    public class BaseEntityConfiguration<TEntity, Tkey> : IEntityTypeConfiguration<TEntity>
        where TEntity:BaseEntity<Tkey>
        where Tkey:IEquatable<Tkey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(b => b.Id);
        }
    }
}
