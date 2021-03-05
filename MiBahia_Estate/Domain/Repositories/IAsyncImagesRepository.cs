using MiBahia_Estate;
using MiBahia_Estate.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAsyncImagesRepository:IAsyncRepository<PropertyPhotos>
    {
        Task AddImage(PropertyPhotos entity);
        Task AddImages(IEnumerable<PropertyPhotos> entities);
    }
}
