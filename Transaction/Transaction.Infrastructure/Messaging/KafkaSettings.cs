using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Infrastructure.Messaging
{
    public class KafkaSettings
    {
        public string GroupId { get; set; } = string.Empty;
        public string[] Topics { get; set; } = [];
        public string BootstrapServers { get; set; } = string.Empty;
    }
}
