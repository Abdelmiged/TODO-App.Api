using Domain.Contracts.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<TEntity, TKey>(StoreDbContext _storeDbContext) : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public int Add(TEntity entity)
        {
            _storeDbContext.Set<TEntity>().Add(entity);
            return _storeDbContext.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            _storeDbContext.Set<TEntity>().Remove(entity);
            return _storeDbContext.SaveChanges();
        }

        public IEnumerable<TEntity>? GetAll()
        {
            var entityList = (IEnumerable<TEntity>)_storeDbContext.Set<TEntity>();
            return entityList;
        }

        public TEntity? GetEntity(TKey id)
        {
            var entity = _storeDbContext.Set<TEntity>().Find(id);
            return entity;
        }

        public int Update(TEntity entity)
        {
            _storeDbContext.Set<TEntity>().Update(entity);
            return _storeDbContext.SaveChanges();
        }
    }
}
