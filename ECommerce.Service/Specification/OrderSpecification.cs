using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Models.Order;
using ECommerce.Domain.Specification;

namespace ECommerce.Service.Specification
{
    public class OrderSpecification:BaseSpecification<Order,Guid>
    {
        public OrderSpecification(string email):base(o=>o.UserEmail==email)
        {
            AddIncludes();
            orderbyDescending(o => o.OrderDate);    
        }
        public OrderSpecification(Guid id) : base(o => o.Id == id)
        {
            AddIncludes();
        }
        protected override void AddIncludes()
        {
            base.AddIncludes();

            Includes.Add(o => o.Items);
            Includes.Add(o => o.DeliveryMethod);
        }
    }
}
