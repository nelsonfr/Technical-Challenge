using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Domain
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
