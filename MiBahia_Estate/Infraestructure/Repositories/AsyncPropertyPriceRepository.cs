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
    public class AsyncPropertyPriceRepository:AsyncRepository<PropertyPrice>, IAsyncPropertyPriceRepository
    {
        private new readonly bahia_estateContext _context;

        public AsyncPropertyPriceRepository(bahia_estateContext context):base(context)
        {
            this._context = context;
        }

        public Task<IEnumerable<Property>> GetPropertiesByMaximumPrice(int maximum)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> GetPropertiesByMinimumPrice(int minimum)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Property>> GetPropertiesByPriceRange(int minimum, int maximum)
        {
            return await _context.Houses.Where(x => x.PropertyPrice.Price>=minimum && x.PropertyPrice.Price<=maximum)
                                            .Include(x=>x.PropertyPhotos)
                                            .Include(x=>x.PropertyAddresses)
                                            .Include(x=>x.PropertyPrice).ToListAsync();
        }
    }
}
