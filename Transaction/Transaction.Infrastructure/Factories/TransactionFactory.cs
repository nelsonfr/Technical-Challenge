using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Application.ViewModels;
using Transaction.Domain.Entities;
using Transaction.Domain.Transactions;

namespace Transaction.Infrastructure.Factories
{
    public class TransactionFactory: ITransactionFactory
    {

        public TransactionEntity CreateTransactionEntity(Guid TransactionExternalId, Guid SourceAccountId, Guid TargetAccountId, int TransferTypeId, decimal Value)
        {
            return new TransactionEntity
            {
                CreatedAt = DateTime.UtcNow,
                TransferTypeId = TransferTypeId,
                Id = TransactionExternalId,
                SourceAccountId = SourceAccountId,
                TargetAccountId = TargetAccountId,
                Value = Value,
                Status = Domain.Enums.Status.Pending

            };
        }
    }
}
