using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAsyncImagesRepository<TEntity> where TEntity: class
    {
        Task AddImage(TEntity entity);
        Task AddImages(IEnumerable<TEntity> entities);
    }
}
