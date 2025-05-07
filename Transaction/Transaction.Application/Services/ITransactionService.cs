using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Application.DTOs;
using Transaction.Application.ViewModels;
using Transaction.Domain.Transactions.Events;

namespace Transaction.Application.Services
{
    public interface ITransactionService
    {
        Task<Guid> CreateTransaction(CreateTransactionDTO transactionDTO);
        Task<TransactionDTO> GetTransaction(RetrieveTransactionDTO retrieveTransactionDTO);
        Task<bool> ProcessFraud(TransactionCreatedEvent transactionCreatedEvent);
    }
}
