using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Infrastructure.Messaging
{
    public abstract class KafkaConsumerBase
    {
        protected readonly IConfiguration _configuration;
        
        protected KafkaConsumerBase(IConfiguration config)
        {
            _configuration = config;
        }

        protected IConsumer<Ignore, string> BuildConsumer(string groupId)
        {
            var config = KafkaHelper.GetDetaultConsumerConfig(_configuration, groupId);
            return new ConsumerBuilder<Ignore, string>(config).Build();
        }
    }
}
