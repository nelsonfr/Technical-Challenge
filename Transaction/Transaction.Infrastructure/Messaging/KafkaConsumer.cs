using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Application.Messaging;

namespace Transaction.Infrastructure.Messaging
{
    public class KafkaConsumer:IKafkaConsumer
    {
        private readonly KafkaSettings _settings;
        private readonly IConsumer<string, string> _consumer;

        public KafkaConsumer(IOptions<KafkaSettings> settings)
        {
            _settings = settings.Value;
            var config = KafkaHelper.GetDetaultConsumerConfig(_settings);
            var consumer = new ConsumerBuilder<string, string>(config).Build();
            consumer.Subscribe(_settings.Topics);
            _consumer = consumer;
            
        }

        public MessageResult Consume()
        {
            var result = _consumer.Consume();
            var messageResult = new MessageResult { Timestamp = result.Message.Timestamp.UtcDateTime, Message = result.Message.Value, Key = result.Message.Key, };
            return messageResult;
        }
    }
}
