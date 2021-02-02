using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MiBahia_Estate.Repositories
{
    public class AsyncHouseRepository : AsyncRepository<House>, IAsyncHouseRepository
    {
        public AsyncHouseRepository(bahia_estateContext context, DbSet<House> property): base(context,property)
        {

        }
     
        public async Task<IEnumerable<Property>> SearchByBathrooms(int bathrooms)
        {
            return await House.Include(x => x.House).Where(x => x.House.Bathrooms == bathrooms)
                                                       .ToListAsync();
        }

        public async Task<IEnumerable<Property>> SearchByRooms(int rooms)
        {
            return await House.Include(x => x.House).Where(x => x.House.Rooms == rooms)
                                                       .ToListAsync();
        }

        public async Task<IEnumerable<Property>> SearchByRoomsBathrooms(int rooms, int bathrooms)
        {
            return await House.Include(x => x.House).Where(x => x.House.Rooms == rooms && x.House.Bathrooms == bathrooms)
                                                       .ToListAsync();
        }

        public async Task<IEnumerable<Property>> SearchOutstandingPropertiesByBathrooms(int bathrooms, bool outstanding)
        {
            return await House.Include(x => x.House).Where(x => x.House.Bathrooms == bathrooms && x.House.Outstanding == outstanding)
                                                       .ToListAsync();
        }

        public async Task<IEnumerable<Property>> SearchOutstandingPropertiesByRooms(int rooms, bool outstanding)
        {
            return await House.Include(x => x.House).Where(x => x.House.Rooms == rooms && x.House.Outstanding == outstanding)
                                                       .ToListAsync();
        }

        public async Task<IEnumerable<Property>> SearchOutstandingPropertiesByRoomsOrBathrooms(int rooms, int bathrooms, bool outstanding)
        {
            return await House.Include(x => x.House).Where(x => x.House.Rooms == rooms && x.House.Bathrooms == bathrooms && x.House.Outstanding == outstanding)
                                                       .ToListAsync();
        }

        public bahia_estateContext BahiaContext
        {
            get { return _context as bahia_estateContext; }
        }

        public DbSet<House> House
        {
            get { return _entities as DbSet<House>; }
        }
    }
}
