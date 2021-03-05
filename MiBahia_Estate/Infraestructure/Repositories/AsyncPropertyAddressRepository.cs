using Domain.Repositories;
using MiBahia_Estate;
using MiBahia_Estate.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class AsyncPropertyAddressRepository:AsyncRepository<PropertyAddresses>, IAsyncPropertyAddressRepository
    {
        private new readonly bahia_estateContext _context;

        public AsyncPropertyAddressRepository(bahia_estateContext context):base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PropertyAddresses>> GetByAddress(string address)
        {
            return await _context.PropertiesAddresses.Where(x => x.Address.Contains(address)).ToListAsync();
        }
    }
}
