using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 
using Microsoft.EntityFrameworkCore;
using Transaction.Infrastructure.DbContext;
using Transaction.Domain.Repositories;
using Transaction.Infrastructure.Repositories;
using Transaction.Application;
using Transaction.Domain.Transactions;
using Transaction.Infrastructure.Factories;
using Transaction.Application.Messaging;
using Transaction.Infrastructure.Messaging;

namespace Transaction.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var conn = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<TransactionDbContext>(options =>
                options.UseNpgsql(conn));

            services.AddScoped<ITransactionDbContext>(provider =>
                provider.GetRequiredService<TransactionDbContext>());

            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddScoped<IKafkaProducer, TransactionProducer>();
            services.AddScoped<IKafkaConsumer, TransactionConsumer>();

            services.AddSingleton<ITransactionFactory, TransactionFactory>();

            return services;
        }
    }
}
