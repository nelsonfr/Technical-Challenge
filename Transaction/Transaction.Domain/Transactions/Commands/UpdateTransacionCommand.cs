using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Domain.Enums;

namespace Transaction.Domain.Transactions.Commands
{
    public class UpdateTransacionStatusCommand
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }

        public UpdateTransacionStatusCommand(Guid id, Status status)
        {
            Id = id;
            Status = status;
        }
    }
}
