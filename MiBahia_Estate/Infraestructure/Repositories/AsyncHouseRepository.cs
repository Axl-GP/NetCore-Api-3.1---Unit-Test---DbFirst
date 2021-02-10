using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MiBahia_Estate.Repositories
{
    public class AsyncHouseRepository : AsyncRepository<Property>, IAsyncHouseRepository
    {
        public AsyncHouseRepository(bahia_estateContext context): base(context)
        {

        }
     
        public async Task<IEnumerable<Property>> SearchByBathrooms(int bathrooms)
        {
            return await BahiaContext.Houses.Include(x => x.House).ThenInclude(x=> new { x.PropertyAddresses,x.PropertyPhotos,x.PropertyPrice})
                                                .Where(x => x.House.Bathrooms == bathrooms)
                                                .ToListAsync();
        }

        public async Task<IEnumerable<Property>> SearchByRooms(int rooms)
        {
            return await BahiaContext.Houses.Include(x => x.House).ThenInclude(x => new { x.PropertyAddresses, x.PropertyPhotos, x.PropertyPrice })
                                                .Where(x => x.House.Rooms == rooms)
                                                .ToListAsync();
        }

        public async Task<IEnumerable<Property>> SearchByRoomsBathrooms(int rooms, int bathrooms)
        {
            return await BahiaContext.Houses.Include(x => x.House).ThenInclude(x => new { x.PropertyAddresses, x.PropertyPhotos, x.PropertyPrice })
                                                .Where(x => x.House.Rooms == rooms && x.House.Bathrooms == bathrooms)
                                                .ToListAsync();
        }

        public async Task<IEnumerable<Property>> SearchOutstandingProperties(bool outstanding)
        {
            return await BahiaContext.Houses.Include(x => x.House).ThenInclude(x => new { x.PropertyAddresses, x.PropertyPhotos, x.PropertyPrice })
                                                .Where(x=> x.House.Outstanding == outstanding)
                                                .ToListAsync();
        }


        public async Task<IEnumerable<Property>> SearchOutstandingPropertiesByBathrooms(int bathrooms, bool outstanding)
        {
            return await BahiaContext.Houses.Include(x => x.House).ThenInclude(x => new { x.PropertyAddresses, x.PropertyPhotos, x.PropertyPrice })
                                                .Where(x => x.House.Bathrooms == bathrooms && x.House.Outstanding == outstanding)
                                                .ToListAsync();
        }

        public async Task<IEnumerable<Property>> SearchOutstandingPropertiesByRooms(int rooms, bool outstanding)
        {
            return await BahiaContext.Houses.Include(x => x.House).ThenInclude(x => new { x.PropertyAddresses, x.PropertyPhotos, x.PropertyPrice })
                                                .Where(x => x.House.Rooms == rooms && x.House.Outstanding == outstanding)
                                                .ToListAsync();
        }

        public async Task<IEnumerable<Property>> SearchOutstandingPropertiesByRoomsAndBathrooms(int rooms, int bathrooms, bool outstanding)
        {
            return await BahiaContext.Properties.Include(x=>x.House).ThenInclude(x => new { x.PropertyAddresses, x.PropertyPhotos, x.PropertyPrice })
                                        .Where(x => x.House.Rooms == rooms && x.House.Bathrooms == bathrooms && x.House.Outstanding == outstanding)
                                        .ToListAsync();
        }

        public bahia_estateContext BahiaContext
        {
            get { return _context as bahia_estateContext; }
        }

       
    }
}
