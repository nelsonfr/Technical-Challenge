using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Domain.Exceptions
{
    public class TransactionNotFoundException : Exception
    {
        public TransactionNotFoundException(Guid externalId, DateTime createdAt)
            : base($"Transaction with external ID {externalId} and created at {createdAt} was not found.")
        {
        }
    }
}
