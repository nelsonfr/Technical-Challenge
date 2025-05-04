using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Domain.Enums;

namespace Transaction.Domain.Entities
{
    public class TransactionEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TransferTypeId { get; set; }
        public Status Status { get; set; }
        public Guid SourceAccountId { get; set; }
        public Guid TargetAccountId { get; set; }
        public decimal Value { get; set; }

    }
}
