using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Transaction.Application.DTOs;
using Transaction.Application.ViewModels;
using Transaction.Domain.Entities;
using Transaction.Domain.Repositories;
using Transaction.Domain.Transactions.Queries;

namespace Transaction.Application.Handlers
{
    public class TransactionQueryHandler(ITransactionRepository transactionRepository)
    {
        public async Task<TransactionDTO> GetTask(GetTransactionQuery getTransactionQuery)
        {
            var tasks = await transactionRepository.GetAllByIdAsync(getTransactionQuery.TransactionExternalId, CancellationToken.None);

        }
    }
}
