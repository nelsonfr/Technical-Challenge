using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Transaction.Application.DTOs;
using Transaction.Application.ViewModels;
using Transaction.Domain.Entities;
using Transaction.Domain.Exceptions;
using Transaction.Domain.Repositories;
using Transaction.Domain.Transactions.Queries;

namespace Transaction.Application.Handlers
{
    public class TransactionQueryHandler(ITransactionRepository transactionRepository)
    {
        public async Task<TransactionDTO> GetTransaction(GetTransactionQuery getTransactionQuery)
        {
            var transaction = await transactionRepository.GetByIdAsync(getTransactionQuery.TransactionExternalId, CancellationToken.None) ?? throw new TransactionNotFoundException(getTransactionQuery.TransactionExternalId, getTransactionQuery.CreatedAt); 
            
            return TransactionDTO.FromEntity(transaction);

        }

        public async Task<IEnumerable<TransactionDTO>> GetTransactionsByTargetAccountId24Hours(GetTransactionsByTargetAccountId24Hours getTransactions)
        {
            var transactions = await transactionRepository.GetAllByTargetIdAsync(getTransactions.TargetAccountId, CancellationToken.None) ?? throw new TransactionNotFoundException(getTransactions.TargetAccountId, DateTime.UtcNow);
            return transactions.Where(x =>  x.CreatedAt.Date == DateTime.UtcNow.Date ).Select(x => TransactionDTO.FromEntity(x));
        }

        public async Task<IEnumerable<TransactionDTO>> GetTransactionsBySourceAccountId24Hours(GetTransactionsBySourceAccoundId24Hours getTransactions)
        {
            var transactions = await transactionRepository.GetAllBySourceIdAsync(getTransactions.sourceAccountId, CancellationToken.None) ?? throw new TransactionNotFoundException(getTransactions.sourceAccountId, DateTime.UtcNow);
            return transactions.Where(x => x.CreatedAt.Date == DateTime.UtcNow.Date).Select(x => TransactionDTO.FromEntity(x));
        }
    }
}
