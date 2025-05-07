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
using Transaction.Domain.Transactions.Events;
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

        public async Task<bool> ProcessFraud(TransactionCreatedEvent transactionCreatedEvent)
        {
            //It is fraud
            //If the value is greater than 2000
            //If the acumulated per day is greater than 20000 (is it by sourceAccountId? targetAccountId? both?)

            var getTransactionQuery = new GetTransactionQuery(transactionCreatedEvent.TransactionId, DateTime.UtcNow);
            var transaction = await mediator.SendAsync<TransactionDTO>(getTransactionQuery);

            var getTransactionsBySourceQuery = new GetTransactionsBySourceAccoundId24Hours(transactionCreatedEvent.SourceAccountId);
            var transactionsBySource = await mediator.SendAsync<IEnumerable<TransactionDTO>>(getTransactionsBySourceQuery);
            var getTransactionsByTargetQuery = new GetTransactionsByTargetAccountId24Hours(transactionCreatedEvent.TargetAccountId);
            var transactionsByTarget = await mediator.SendAsync<IEnumerable<TransactionDTO>>(getTransactionsByTargetQuery);

            var accumulatedBySource = transactionsBySource.Where(x => x.status == Domain.Enums.Status.Approved).Sum(_ => _.Value);
            var accumulatedByTarget = transactionsByTarget.Where(x => x.status == Domain.Enums.Status.Approved).Sum(_ => _.Value);


            return (accumulatedByTarget > 20000 || accumulatedBySource > 20000 || transaction.Value > 2000);
        }
    }
}
