using MiBahia_Estate.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IAsyncUnitOfWork: IDisposable
    {
        IAsyncHouseRepository Houses { get;  }
        IAsyncBuildingSiteRepository BuildingSites { get; }

        Task<int> Complete();
    }
}
