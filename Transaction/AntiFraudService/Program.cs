using AntiFraudService;
using Transaction.Application.Messaging;
using Transaction.Application.Services;
using Transaction.Infrastructure.Messaging;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddScoped<IKafkaConsumer, TransactionConsumer>();
builder.Services.AddScoped<IKafkaProducer, TransactionProducer>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
var host = builder.Build();
host.Run();
