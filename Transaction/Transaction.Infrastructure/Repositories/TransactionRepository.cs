using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Domain.Entities;
using Transaction.Domain.Repositories;

namespace Transaction.Infrastructure.Repositories
{
    public class TransactionRepository(ITransactionRepository transactionRepository) : ITransactionRepository
    {
        private readonly ITransactionRepository _transactionRepository = transactionRepository;

        public Task AddAsync(TransactionEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TransactionEntity?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
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
