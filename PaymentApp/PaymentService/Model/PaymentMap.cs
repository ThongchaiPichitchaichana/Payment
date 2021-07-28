using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentService.Model
{
    public sealed class PaymentMap : ClassMap<Payment>
    {
        public PaymentMap()
        {
            Map(x => x.TransactionIdentificator).Name("TransactionIdentificator");
            Map(x => x.Amount).Name("Amount");
            Map(x => x.CurrencyCode).Name("CurrencyCode");
            Map(x => x.TransactionDate).Name("TransactionDate");
            Map(x => x.Status).Name("Status");



        }
    }
}
