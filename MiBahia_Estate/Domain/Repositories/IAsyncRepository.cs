﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MiBahia_Estate.Repositories
{
    public interface IAsyncRepository<TEntity> where TEntity:class
    {
        Task <IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(int id);

        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity,bool>> predicate);

        Task<TEntity> SingleOrDefault(Expression<Func<TEntity,bool>> predicate);

        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
