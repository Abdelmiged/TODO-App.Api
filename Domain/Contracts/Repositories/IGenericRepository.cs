using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repositories
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public TEntity? GetEntity(TKey id);
        public IEnumerable<TEntity>? GetAllAsync();
        public int AddAsync(TEntity entity);
        public int UpdateAsync(TEntity entity);
        public int DeleteAsync(TEntity entity);
    }
}
