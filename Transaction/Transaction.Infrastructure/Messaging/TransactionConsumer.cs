using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Application.Messaging;

namespace Transaction.Infrastructure.Messaging
{
    public class TransactionConsumer: KafkaConsumerBase, IKafkaConsumer
    {
        public TransactionConsumer(IConfiguration config)
       : base(config) { }

        public async Task StartConsumingAsync(CancellationToken cancellationToken)
        {
            using var consumer = BuildConsumer("transaction-worker-group");
            consumer.Subscribe("transactions-topic");

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var result = consumer.Consume(cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
                consumer.Close();
            }
        }
    }
}
