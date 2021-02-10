using MiBahia_Estate;
using MiBahia_Estate.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAsyncPropertyAddressRepository : IAsyncRepository<PropertyAddresses>
    {
        Task<IEnumerable<Property>> GetByAddress(string address);
    }
}
