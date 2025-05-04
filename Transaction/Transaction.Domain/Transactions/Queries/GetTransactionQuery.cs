using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Domain.Transactions.Queries
{
    public class GetTransactionQuery
    {
        public Guid TransactionExternalId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
