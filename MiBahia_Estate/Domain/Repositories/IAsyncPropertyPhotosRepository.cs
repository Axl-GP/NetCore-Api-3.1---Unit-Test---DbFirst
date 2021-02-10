using MiBahia_Estate;
using MiBahia_Estate.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAsyncPropertyPhotosRepository: IAsyncRepository<PropertyPrice>
    {
        Task<IEnumerable<Property>> GetPropertiesByPriceRange(int minimum, int maximum);
        Task<IEnumerable<Property>> GetPropertiesByMinimumPrice(int minimum);
        Task<IEnumerable<Property>> GetPropertiesByMaximumPrice(int maximum);
    }
}
