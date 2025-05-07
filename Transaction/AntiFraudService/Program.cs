using AntiFraudService;
using Transaction.Application.Messaging;
using Transaction.Application.Services;
using Transaction.Infrastructure.Messaging;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddScoped<IKafkaConsumer, KafkaConsumer>();
builder.Services.AddScoped<IKafkaProducer, KafkaProducer>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
var host = builder.Build();
host.Run();
