using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Domain.Transactions.Events;

namespace Transaction.Application.Handlers
{
    public class TransactionEventHandler
    {
        public async Task HandleTransactionCreatedEvent(TransactionCreatedEvent transactionCreatedEvent)
        {

        }
    }
}
