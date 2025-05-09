using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Infrastructure.Messaging.TopicInitializer
{
    public class KafkaStartupFilter : IStartupFilter
    {
        private readonly KafkaTopicInitializer _initializer;

        public KafkaStartupFilter(KafkaTopicInitializer initializer)
        {
            _initializer = initializer;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            // Ensure Kafka topics are created BEFORE the app starts (and before any hosted service runs)
            _initializer.InitializeAsync().GetAwaiter().GetResult();
            return next;
        }      
    }

}
