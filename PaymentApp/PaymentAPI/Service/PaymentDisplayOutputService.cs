using PaymentAPI.Interface;
using PaymentAPI.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentAPI.Service
{
    public class PaymentDisplayOutputService : IPaymentDisplayOutput
    {


        public PaymentDisplayOutputService()
        {
           
        }
        public List<PaymentDisplayOutput> GetPaymentDisplayOutputs()
        {
            List<PaymentDisplayOutput> OutputList = new List<PaymentDisplayOutput>();
            PaymentDisplayOutput Output = new PaymentDisplayOutput();
            using (var db = new PaymentContext())
            {
               
                List<Payment> PaymentList = db.Payment.ToList();
                foreach (var str in PaymentList)
                {
                    Output = null;
                    Output.TransactionIdentificator = str.TransactionIdentificator;
                    Output.payment = str.Amount + str.CurrencyCode;
                    if (str.Status == "Approved") { Output.Status = "A"; }
                    if (str.Status == "Rejected" || str.Status == "Failed") { Output.Status = "R"; }
                    if (str.Status == "Done" || str.Status == "Finished") { Output.Status = "D"; }
                    OutputList.Add(Output);
                }
            }
                return OutputList;
            }
    }
}
