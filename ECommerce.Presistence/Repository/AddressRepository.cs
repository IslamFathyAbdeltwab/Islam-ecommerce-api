using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Contract;
using ECommerce.Presistence.Contexts;
using ECommerce.Presistence.Model.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Presistence.Repository
{
    public class AddressRepository(StoreIdentityDbContext context) : IAddressRepository
    {
        public async Task<Address> AddAddressAsync(Address address)
        {
             await context.AddAsync(address);
             await context.SaveChangesAsync();

            return await GetAddressAsync(address.UserId);
        }

        public async Task<Address> GetAddressAsync(string userId)
        {
            var address = await context.Set<Address>().FirstOrDefaultAsync(a => a.UserId == userId);

            return address;
        }
    }
}
