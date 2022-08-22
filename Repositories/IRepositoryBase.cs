using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PoupaDevAPI.Models;

namespace PoupaDevAPI.Repositories
{
    public interface IRepositoryBase<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : struct
    {
        List<TEntity> GetAll();
        TEntity GetById(TKey id);
        void CreateOrUpdate(TEntity entity);        
        void Delete(TKey id);
    }
}