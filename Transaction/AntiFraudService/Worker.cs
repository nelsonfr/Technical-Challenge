using Transaction.Application.Messaging;

namespace AntiFraudService
{
    public class Worker(IKafkaConsumer kafkaConsumer) : BackgroundService
    {    

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await kafkaConsumer.StartConsumingAsync( stoppingToken);
            }
        }
    }
}
