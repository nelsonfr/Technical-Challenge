using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Application;
using Transaction.Domain.Entities;
using Transaction.Domain.Repositories;

namespace Transaction.Infrastructure.Repositories
{
    public class TransactionRepository(ITransactionDbContext dbContext) : ITransactionRepository
    {
        private readonly ITransactionDbContext _dbContext = dbContext;

        public async Task<Guid> AddAsync(TransactionEntity entity, CancellationToken cancellationToken)
        {
            _dbContext.Transactions.Add(entity);
            await _dbContext.SaveNewChangesAsync(cancellationToken);
            return entity.Id;
            
        }

        public async Task<IEnumerable<TransactionEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Transactions.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TransactionEntity>> GetAllByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Transactions.Where(x => x.Id == id).ToListAsync(cancellationToken);
        }

        public async Task<TransactionEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Transactions.FindAsync(id, cancellationToken);
        }

        public void Remove(TransactionEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TransactionEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
