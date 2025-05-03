﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Application.DTOs;
using Transaction.Application.ViewModels;

namespace Transaction.Application.Services
{
    public interface ITransactionService
    {
        Task<CreateTransactionDTO> CreateTransaction(CreateTransactionDTO transactionDTO);
        Task<TransactionDTO> GetTransaction(RetrieveTransactionDTO retrieveTransactionDTO);
    }
}
