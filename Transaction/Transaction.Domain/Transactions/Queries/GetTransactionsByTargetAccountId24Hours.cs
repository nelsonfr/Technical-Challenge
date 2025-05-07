using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Domain.Transactions.Queries
{
    public class GetTransactionsByTargetAccountId24Hours(Guid targetAccountId)
    {
        public Guid TargetAccountId { get; set; } = targetAccountId;
    }
}
