using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Npgsql.Replication.PgOutput.Messages;
using System.Text;
using Transaction.Application.Messaging;
using Transaction.Application.Services;
using Transaction.Domain.Transactions.Events;
using Transaction.Infrastructure.Messaging;

namespace AntiFraudService
{
    public class TransactionConsumer:KafkaConsumer
    {
        protected static readonly string[] topics = ["transaction-created"];
        private readonly ITransactionService _transactionService;


        public TransactionConsumer(IConfiguration configuration, IServiceProvider serviceProvider) : base(topics, configuration)
        {
            var scope = serviceProvider.CreateScope();
            _transactionService = scope.ServiceProvider.GetRequiredService<ITransactionService>();
        }



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

            if (orderMessage != null)
            {
                var IsFraud = await _transactionService.ProcessFraud(orderMessage);
            }
           
        }
    }
}
