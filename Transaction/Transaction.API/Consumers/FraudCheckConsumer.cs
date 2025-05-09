using Newtonsoft.Json;
using Transaction.Application.Services;
using Transaction.Domain.Transactions.Events;
using Transaction.Infrastructure.Messaging;

namespace Transaction.API.Consumers
{
    public class FraudCheckConsumer:KafkaConsumer
    {
        protected static readonly string[] topics = ["transaction-fraud-checked"];
        private readonly ITransactionService _transactionService;

        public FraudCheckConsumer(IConfiguration configuration, IServiceProvider serviceProvider) : base(topics, configuration)
        {
            var scope = serviceProvider.CreateScope();
            _transactionService = scope.ServiceProvider.GetRequiredService<ITransactionService>();
        }


        protected override async Task ConsumeAsync(MessageResult messageResult)
        {

            await base.ConsumeAsync(messageResult);
            switch (messageResult.Topic)
            {
                case "transaction-fraud-checked":
                    await HandleFraudCheck(messageResult.Message);
                    break;
            }

        }


        private async Task HandleFraudCheck(string message)
        {
            var fraudMessage = JsonConvert.DeserializeObject<TransactionFraudCheckedEvent>(message);

            if(fraudMessage != null)
            {
                await _transactionService.UpdateTransactionFraudStatus(fraudMessage);
            }
        }

    }
}
