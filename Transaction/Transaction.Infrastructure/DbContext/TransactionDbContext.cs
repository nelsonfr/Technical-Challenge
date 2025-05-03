namespace Transaction.Infrastructure.DbContext
{
    using Microsoft.EntityFrameworkCore;
    using Transaction.Application;
    using Transaction.Domain.Entities;

    public class TransactionDbContext : DbContext, ITransactionDbContext
    {
        public DbSet<TransactionEntity> Transactions { get; set; }

        public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
            : base(options)
        {
        }

        public async Task<int> SaveNewChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        
    }
}
