using MiBahia_Estate.Repositories;
using MiBahia_Estate.Solares;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Persistence.Repositories
{
    public class AsyncBuildingSiteRepository : AsyncRepository<BuildingSite>, IAsyncBuildingSiteRepository
    {

        public AsyncBuildingSiteRepository(bahia_estateContext context) : base(context)
        {
           
        }
        public async Task<IEnumerable<BuildingSite>> GetBuildingSitesbyPricePerMeter(int minimum, int maximum)
        {
            return await Context.BuildingSites.Where(x => x.PricePerMeter >= minimum && x.PricePerMeter <= maximum).ToListAsync();
        }

        public async Task<IEnumerable<BuildingSite>> GetBuildingSitesbySize(int minimumSize, int maximumSize)
        {
            return await Context.BuildingSites.Where(x => x.Area >= minimumSize && x.Area <= maximumSize).ToListAsync();
        }

        public async Task<IEnumerable<BuildingSite>> GetOutstandingBuildingSites(bool outstanding)
        {
            return await Context.BuildingSites.Where(x => x.Outstanding == outstanding).ToListAsync();
        }

        
        public bahia_estateContext Context
        {
            get { return _context as bahia_estateContext; }
        }
    }
}
