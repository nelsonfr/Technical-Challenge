using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Infrastructure.Messaging
{
    public class MessageResult
    {
        public string Topic { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
    }
}
