using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoupaDevAPI.Models;

namespace PoupaDevAPI.Repositories
{
    public interface IRepositoryBase<TEntity, TKey> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(TKey id);
        Task<List<TEntity>> GetDeleted();
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity, TKey id);
        Task Delete(TKey id);
    }
}