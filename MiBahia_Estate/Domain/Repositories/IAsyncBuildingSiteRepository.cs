using MiBahia_Estate.Solares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Repositories
{
    public interface IAsyncBuildingSiteRepository: IAsyncRepository<BuildingSite>
    {
        Task<IEnumerable<BuildingSite>> GetOutstandingBuildingSites(bool outstanding);

        Task<IEnumerable<BuildingSite>> GetBuildingSitesbySize(int minimum, int maximum);
        Task<IEnumerable<BuildingSite>> GetBuildingSitesbyPricePerMeter(int minimumSize, int maximumSize);

    }
}
