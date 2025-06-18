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
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<int> AddAsync(TEntity entity);
        public Task<int> UpdateAsync(Guid id);
        public Task<int> DeleteAsync(Guid id);
    }
}
