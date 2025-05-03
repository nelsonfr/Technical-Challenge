using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Application.ViewModels
{
    public class CreateTransactionDTO
    {
        public Guid SourceAccountId { get; set; }
        public Guid TargetAccountId { get; set; }
        public int TransferTypeId { get; set; }
        public decimal Value { get; set; }
    }
}
