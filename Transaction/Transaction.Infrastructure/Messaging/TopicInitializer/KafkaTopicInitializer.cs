using Confluent.Kafka;
using Confluent.Kafka.Admin;
using Microsoft.Extensions.Configuration;

namespace Transaction.Infrastructure.Messaging.TopicInitializer;

public class KafkaTopicInitializer
{
    private readonly IConfiguration _configuration;

    public KafkaTopicInitializer(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task InitializeAsync()
    {
        var config = new AdminClientConfig
        {
            BootstrapServers = _configuration["Kafka:BootstrapServers"]
        };

        using var adminClient = new AdminClientBuilder(config).Build();

        var topics = new[]
        {
            new TopicSpecification { Name = "transaction-created", NumPartitions = 1, ReplicationFactor = 1 },
            new TopicSpecification { Name = "transaction-fraud-checked", NumPartitions = 1, ReplicationFactor = 1 }
        };

        try
        {
            await adminClient.CreateTopicsAsync(topics);
            Console.WriteLine("✅ Kafka topics created.");
        }
        catch (CreateTopicsException ex)
        {
            foreach (var result in ex.Results)
            {
                if (result.Error.Code != ErrorCode.TopicAlreadyExists)
                    Console.WriteLine($"❌ Error creating topic {result.Topic}: {result.Error.Reason}");
            }
        }
    }
}
