using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Application.ViewModels
{
    public class CreateTransactionDTO
    {
        [Required]
        public Guid SourceAccountId { get; set; }
        [Required]
        public Guid TargetAccountId { get; set; }
        [Required]
        public int TransferTypeId { get; set; }
        [Required]
        public decimal Value { get; set; }
    }
}
