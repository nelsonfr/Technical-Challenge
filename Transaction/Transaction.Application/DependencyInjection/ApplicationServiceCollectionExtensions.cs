using FluentMediator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Application.Handlers;
using Transaction.Application.Services;
using Transaction.Application.ViewModels;
using Transaction.Domain.Entities;
using Transaction.Domain.Transactions.Commands;
using Transaction.Domain.Transactions.Events;
using Transaction.Domain.Transactions.Queries;

namespace Transaction.Application.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<TransactionCommandHandler>();
            services.AddScoped<TransactionQueryHandler>();
            services.AddScoped<TransactionEventHandler>();

            services.AddFluentMediator(builder =>
                {
                    //queries
                    builder.On<GetTransactionQuery>().PipelineAsync().Return<TransactionDTO, TransactionQueryHandler>((handler, request) => handler.GetTransaction(request));
                    builder.On<GetTransactionsByTargetAccountId24Hours>().PipelineAsync().Return<IEnumerable<TransactionDTO>, TransactionQueryHandler>((handler, request) => handler.GetTransactionsByTargetAccountId24Hours(request));
                    builder.On<GetTransactionsBySourceAccoundId24Hours>().PipelineAsync().Return<IEnumerable<TransactionDTO>, TransactionQueryHandler>((handler, request) => handler.GetTransactionsBySourceAccountId24Hours(request));
                    //commands
                    builder.On<CreateNewTransactionCommand>().PipelineAsync().Return<Guid, TransactionCommandHandler>((handler, request) => handler.CreateNewTask(request));
                    //events
                    builder.On<TransactionCreatedEvent>().PipelineAsync().Call<TransactionEventHandler>((handler, request) => handler.HandleTransactionCreatedEvent(request));
                   
                }
            );

            return services;
        }
    }
}
