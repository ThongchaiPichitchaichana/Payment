using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentAPIService.Models
{
    public class PaymentDisplayOutput
    {
        [Required]
        [Key]
        public string TransactionIdentificator { get; set; }
        [Required]
        public string payment { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
