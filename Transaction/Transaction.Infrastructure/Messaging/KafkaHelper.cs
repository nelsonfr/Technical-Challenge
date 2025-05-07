using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Infrastructure.Messaging
{
    public static class KafkaHelper
    {
        public static ConsumerConfig GetDetaultConsumerConfig(KafkaSettings settings) =>
            new ConsumerConfig
            {
                BootstrapServers = settings.BootstrapServers,
                GroupId = settings.GroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

        public static ProducerConfig GetDefaultProducerConfig(KafkaSettings settings) =>
            new ProducerConfig
            {
                BootstrapServers = settings.BootstrapServers
            };
    }
}
