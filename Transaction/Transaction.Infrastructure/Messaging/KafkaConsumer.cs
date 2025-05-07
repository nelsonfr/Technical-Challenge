using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Application.Messaging;

namespace Transaction.Infrastructure.Messaging
{
    public class KafkaConsumer : BackgroundService
    {
        private readonly IConsumer<string, string> _consumer;

        public KafkaConsumer(string[] topics, IConfiguration configuration)
        {
            var config = KafkaHelper.GetDetaultConsumerConfig(configuration);
            _consumer = new ConsumerBuilder<string, string>(config).Build();
            _consumer.Subscribe(topics);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(async () => {
                await HandleConsume(stoppingToken);
                
            }, stoppingToken);
        }

        protected async Task HandleConsume(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {

                var consumeResult = _consumer.Consume(cancellationToken);
                await ConsumeAsync(new MessageResult { Topic = consumeResult.Topic, Message = consumeResult.Message.Value, Key = consumeResult.Message.Key });
            }
            _consumer.Close();
        }

        protected virtual Task ConsumeAsync(MessageResult messageResult)
        {
            return Task.CompletedTask;
        }
    }
}
