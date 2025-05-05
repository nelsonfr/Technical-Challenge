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
        public static ConsumerConfig GetDetaultConsumerConfig(IConfiguration config, string groupId) =>
            new ConsumerConfig
            {
                BootstrapServers = config["Kafka:BootstrapServers"],
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

        public static ProducerConfig GetDefaultProducerConfig(IConfiguration config) =>
            new ProducerConfig
            {
                BootstrapServers = config["Kafka:BootstrapServers"]
            };
    }
}
