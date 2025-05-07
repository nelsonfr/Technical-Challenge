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
        public static ConsumerConfig GetDetaultConsumerConfig(IConfiguration configuration) =>
            new ConsumerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"],
                GroupId = configuration["Kafka:GroupId"],
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

        public static ProducerConfig GetDefaultProducerConfig(IConfiguration configuration) =>
            new ProducerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"]
            };
    }
}
