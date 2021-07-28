using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace PaymentService.Model
{
    [Serializable]
    [XmlRoot("Transaction")]
    public class PaymentXML
    {
        [Required]
        [XmlElement("TransactionIdentificator")]
        public string TransactionIdentificator { get; set; }
        [Required]
        [XmlElement("Amount")]
        public string Amount { get; set; }
        [Required]
        [XmlElement("CurrencyCode")]
        public string CurrencyCode { get; set; }

        [Required]
        [XmlElement("TransactionDate")]
        public string TransactionDate { get; set; }

        [Required]
        [XmlElement("Status")]
        public string Status { get; set; }
    }
}
