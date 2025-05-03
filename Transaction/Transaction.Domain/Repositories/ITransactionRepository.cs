using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Domain.Entities;

namespace Transaction.Domain.Repositories
{
    public interface ITransactionRepository: IRepository<TransactionEntity>
    {
        
    }
}
