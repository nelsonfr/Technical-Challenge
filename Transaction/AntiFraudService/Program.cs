using AntiFraudService;
using Transaction.Application.DependencyInjection;
using Transaction.Application.Messaging;
using Transaction.Application.Services;
using Transaction.Domain.Transactions;
using Transaction.Infrastructure.DependencyInjection;
using Transaction.Infrastructure.Factories;
using Transaction.Infrastructure.Messaging;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<TransactionConsumer>(); 
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
var host = builder.Build();
host.Run();
