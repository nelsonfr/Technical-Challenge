using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Domain.Transactions.Commands
{
    public class CreateNewTransactionCommand
    {
        public Guid SourceAccountId { get; set; }
        public Guid TargetAccountId { get; set; }
        public int TransferTypeId { get; set; }
        public decimal Value { get; set; }
        public CreateNewTransactionCommand(Guid sourceAccountId, Guid targetAccountId, int transferTypeId, decimal value)
        {
            
        }
    }
}
