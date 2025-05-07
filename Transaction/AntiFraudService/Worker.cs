using Transaction.Application.Messaging;

namespace AntiFraudService
{
    public class Worker(IKafkaConsumer kafkaConsumer, IConfiguration configuration) : BackgroundService
    {    

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            using var consumer = kafkaConsumer.BuildConsumer("")

            while (!stoppingToken.IsCancellationRequested)
            {
                await kafkaConsumer.StartConsumingAsync( stoppingToken);
            }
        }
    }
}
