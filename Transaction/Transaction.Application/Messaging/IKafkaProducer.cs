using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Application.Messaging
{
    public interface IKafkaProducer
    {
        Task PublishAsync(string topic, string message);
    }
}
