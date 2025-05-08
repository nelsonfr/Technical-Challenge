using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Domain.Transactions.Events
{
    public class TransactionFraudCheckedEvent
    {
        public Guid TransactionId { get; set; }
        public bool IsFraud { get; set; }

        public TransactionFraudCheckedEvent(Guid transactionId, bool isFraud)
        {
            TransactionId = transactionId;
            IsFraud = isFraud;
        }
    }
}
