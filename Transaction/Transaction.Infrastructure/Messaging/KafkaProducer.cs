using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Application.Messaging;
using Confluent.Kafka;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Transaction.Infrastructure.Messaging
{
    public class KafkaProducer:IKafkaProducer
    {
        private readonly IProducer<string, string> _producer;
        public KafkaProducer(IConfiguration configuration)
        {
             var config = KafkaHelper.GetDefaultProducerConfig(configuration);
            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public async Task ProduceAsync(string topic, object message)
        {
            var kafkaMessage = new Message<string, string> { Value = JsonConvert.SerializeObject(message) };
            await _producer.ProduceAsync(topic, kafkaMessage);
        }
    }
}
