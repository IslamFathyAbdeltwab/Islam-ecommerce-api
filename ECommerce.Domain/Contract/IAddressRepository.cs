using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Presistence.Model.Identity;

namespace ECommerce.Domain.Contract
{
    public interface IAddressRepository
    {
        Task<Address> GetAddressAsync(string userId);
        Task<Address> AddAddressAsync(Address address);
    }
}
