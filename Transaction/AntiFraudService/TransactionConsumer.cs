using Newtonsoft.Json;
using Transaction.Application.Messaging;
using Transaction.Application.Services;
using Transaction.Domain.Transactions.Events;
using Transaction.Infrastructure.Messaging;

namespace AntiFraudService
{
    public class TransactionConsumer(IConfiguration configuration, ITransactionService transactionService) : KafkaConsumer(topics, configuration)
    {
        protected static readonly string[] topics = ["transaction-created"];

        protected override async Task ConsumeAsync(MessageResult messageResult)
        {

            await base.ConsumeAsync(messageResult);            
            switch (messageResult.Topic)
            {
                case "transaction-created":
                    await HandleTransactionCreated(messageResult.Message);
                    break;
            }
            
        }

        private async Task HandleTransactionCreated(string message)
        {
            var orderMessage = JsonConvert.DeserializeObject<TransactionCreatedEvent>(message);
            var IsFraud = await transactionService.ProcessFraud(orderMessage);

            if (IsFraud)
            {

            }

        }
    }
}
