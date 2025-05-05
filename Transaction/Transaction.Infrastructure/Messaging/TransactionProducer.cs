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
    public class TransactionProducer:IKafkaProducer
    {
        private readonly IConfiguration _config;

        public TransactionProducer(IConfiguration config)
        {
            _config = config;
        }

        public async Task PublishAsync(string topic, string message)
        {
            var producerConfig = KafkaHelper.GetDefaultProducerConfig(_config);
            using var producer = new ProducerBuilder<Null, string>(producerConfig).Build();

            var result = await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });
        }
    }
}
