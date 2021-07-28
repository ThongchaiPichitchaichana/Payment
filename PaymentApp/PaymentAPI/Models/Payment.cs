using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentAPI.Models
{
    public class Payment
    {
        [Key]
        [Required]
        public string TransactionIdentificator { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public string CurrencyCode { get; set; }

        [Required]
        public string TransactionDate { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
