using FluentMediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Domain.Repositories;
using Transaction.Domain.Transactions;
using Transaction.Domain.Transactions.Commands;
using Transaction.Domain.Transactions.Events;

namespace Transaction.Application.Handlers
{
    public class TransactionCommandHandler(ITransactionRepository transactionRepository, 
                                           ITransactionFactory transactionFactory,
                                           IMediator mediator)
    {
        public async Task<Guid> CreateNewTask(CreateNewTransactionCommand createNewTransactionCommand)
        {

            var entity = transactionFactory.CreateTransactionEntity(new Guid(),
                createNewTransactionCommand.SourceAccountId,
                createNewTransactionCommand.TargetAccountId,
                createNewTransactionCommand.TransferTypeId,
                createNewTransactionCommand.Value
                );

            var guid = await transactionRepository.AddAsync(entity, CancellationToken.None);
            await mediator.PublishAsync(new TransactionCreatedEvent { TransactionId = guid, SourceAccountId = entity.SourceAccountId, TargetAccountId = entity.TargetAccountId });
            return guid;
        }
    }
}
