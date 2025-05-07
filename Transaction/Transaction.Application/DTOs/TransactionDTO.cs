using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Domain.Entities;
using Transaction.Domain.Enums;

namespace Transaction.Application.ViewModels
{
    public class TransactionDTO
    {
        public Guid TransactionExternalId { get; set; }
        public Guid SourceAccountId { get; set; }
        public Guid TargetAccountId { get; set; }
        public int TransferTypeId { get; set; }
        public decimal Value { get; set; }
        public Status status { get; set; }

        public static TransactionDTO FromEntity(TransactionEntity transactionEntityDto)
        {
            return new TransactionDTO
            {
                TransactionExternalId = transactionEntityDto.Id,
                SourceAccountId = transactionEntityDto.SourceAccountId,
                TargetAccountId = transactionEntityDto.TargetAccountId,
                TransferTypeId = transactionEntityDto.TransferTypeId,
                Value = transactionEntityDto.Value,
                status = transactionEntityDto.Status
            };
        }
    }
}
