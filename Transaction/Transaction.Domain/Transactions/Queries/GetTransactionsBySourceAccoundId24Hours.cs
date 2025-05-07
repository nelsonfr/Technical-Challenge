using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Domain.Transactions.Queries
{
    public class GetTransactionsBySourceAccoundId24Hours(Guid sourceAccountId)
    {
        public Guid sourceAccountId { get; set; } = sourceAccountId;
    }
}
