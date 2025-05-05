using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Application;
using Transaction.Domain.Entities;
using Transaction.Domain.Repositories;
using Transaction.Domain.Exceptions;

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

        public async Task<IEnumerable<TransactionEntity>> GetAllByIdAsync(Guid id,  CancellationToken cancellationToken)
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

        public async Task Update(TransactionEntity entity)
        {
            var transaction = await _dbContext.Transactions.FirstOrDefaultAsync(x => x.Id == entity.Id) ?? throw new TransactionNotFoundException(entity.Id, entity.CreatedAt);
            transaction.TransferTypeId = entity.TransferTypeId;
            transaction.Status = entity.Status;

            await _dbContext.SaveNewChangesAsync(CancellationToken.None);

            
        }
    }
}
