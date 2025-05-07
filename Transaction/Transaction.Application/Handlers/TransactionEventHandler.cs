using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Domain.Transactions.Events;
using Newtonsoft.Json;
using Transaction.Application.Messaging;

namespace Transaction.Application.Handlers
{
    public class TransactionEventHandler(IKafkaProducer producer)
    {
        
        public async Task HandleTransactionCreatedEvent(TransactionCreatedEvent transactionCreatedEvent)
        {
            var eventMessage = JsonConvert.SerializeObject(transactionCreatedEvent);
            await producer.ProduceAsync("transactions-topic", eventMessage);
        }
    }
}
