using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Repositories
{
    public interface IAsyncHouseRepository : IAsyncRepository<House> 
    {
        Task<IEnumerable<Property>> SearchByRooms(int rooms);
        Task<IEnumerable<Property>> SearchByBathrooms(int bathrooms);       
        Task<IEnumerable<Property>> SearchByRoomsBathrooms(int rooms, int bathrooms);
        Task<IEnumerable<Property>> SearchOutstandingProperties(bool outstanding);
        Task<IEnumerable<Property>> SearchOutstandingPropertiesByRooms(int rooms, bool outstanding);
        Task<IEnumerable<Property>> SearchOutstandingPropertiesByBathrooms(int bathrooms, bool outstanding);
        Task<IEnumerable<Property>> SearchOutstandingPropertiesByRoomsAndBathrooms(int rooms, int bathrooms, bool outstanding);
    }
}
