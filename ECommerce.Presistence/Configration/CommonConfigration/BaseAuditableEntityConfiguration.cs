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
    public class BaseAuditableEntityConfiguration<TEntity,Tkey>:BaseEntityConfiguration<TEntity,Tkey>
        where TEntity : BaseAuditableEntity<TEntity,Tkey>
        where Tkey:IEquatable<Tkey>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
            //  here configure 
            //  builder.Property(p => p.CreatedBy).HasColumnType("varchar(50)");
            //  builder.Property(p => p.LastModifedBy).HasColumnType("varchar(50)");

            //and so on
        }
    }
}
