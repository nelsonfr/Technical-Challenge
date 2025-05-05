using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Application.Messaging;
using Transaction.Domain.Transactions.Events;
using Newtonsoft.Json;

namespace Transaction.Application.Handlers
{
    public class TransactionEventHandler(IKafkaProducer producer)
    {
        
        public async Task HandleTransactionCreatedEvent(TransactionCreatedEvent transactionCreatedEvent)
        {
            var eventMessage = JsonConvert.SerializeObject(transactionCreatedEvent);
            await producer.PublishAsync("transactions-topic", eventMessage);
        }
    }
}
