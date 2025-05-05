using FluentMediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Application.DTOs;
using Transaction.Application.ViewModels;
using Transaction.Domain.Repositories;
using Transaction.Domain.Transactions.Commands;
using Transaction.Domain.Transactions.Queries;

namespace Transaction.Application.Services
{
    public class TransactionService(IMediator mediator) : ITransactionService
    {
        

        public async Task<Guid> CreateTransaction(CreateTransactionDTO transactionDTO)
        {
            var newTransactionCommand = new CreateNewTransactionCommand (transactionDTO.SourceAccountId, transactionDTO.TargetAccountId, transactionDTO.TransferTypeId, transactionDTO.Value);
            return await mediator.SendAsync<Guid>(newTransactionCommand);
        }

        public async Task<TransactionDTO> GetTransaction(RetrieveTransactionDTO retrieveTransactionDTO)
        {
            var getTransacionQuery = new GetTransactionQuery(retrieveTransactionDTO.TransactionExternalId, retrieveTransactionDTO.CreatedAt);
            return await mediator.SendAsync<TransactionDTO>(getTransacionQuery);
        }
    }
}
