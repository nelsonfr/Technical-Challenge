using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Domain.Entities;

namespace Transaction.Application
{
    public interface ITransactionDbContext
    {
        DbSet<TransactionEntity> Transactions { get; set; }
        Task<int> SaveNewChangesAsync(CancellationToken cancellationToken);

    }
}
