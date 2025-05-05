using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Domain.Entities;

namespace Transaction.Domain.Transactions
{
    public interface ITransactionFactory
    {
        TransactionEntity CreateTransactionEntity(Guid TransactionExternalId, Guid SourceAccountId, Guid TargetAccountId, int TransferTypeId, decimal Value);
       
    }
}
