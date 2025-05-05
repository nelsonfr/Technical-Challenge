using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Domain.Transactions.Queries
{
    public class GetTransactionQuery(Guid transactionExternalId, DateTime createdAt)
    {
        public Guid TransactionExternalId { get; set; } = transactionExternalId;
        public DateTime CreatedAt { get; set; } = createdAt;
    }
}
