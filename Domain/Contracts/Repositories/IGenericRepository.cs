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
        public IEnumerable<TEntity>? GetAll();
        public int Add(TEntity entity);
        public int Update(TEntity entity);
        public int Delete(TEntity entity);
    }
}
