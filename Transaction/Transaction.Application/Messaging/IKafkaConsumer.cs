using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Application.Messaging
{
    public interface IKafkaConsumer
    {
        Task StartConsumingAsync(CancellationToken cancellationToken);
    }
}
