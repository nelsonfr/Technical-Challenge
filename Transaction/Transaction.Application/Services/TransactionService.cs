using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Application.DTOs;
using Transaction.Application.ViewModels;

namespace Transaction.Application.Services
{
    public class TransactionService : ITransactionService
    {
        public Task<CreateTransactionDTO> CreateTransaction(CreateTransactionDTO transactionDTO)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionDTO> GetTransaction(RetrieveTransactionDTO retrieveTransactionDTO)
        {
            throw new NotImplementedException();
        }
    }
}
