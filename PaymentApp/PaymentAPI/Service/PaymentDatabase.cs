using PaymentAPI.Interface;
using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Service
{
    public class PaymentDatabase : IPaymentDatabase
    {
        public PaymentDatabase()
        {

        }

        public List<Payment> GetAllbyCurrency(string input)
        {
            List<Payment> PaymentList;
            using (var db = new PaymentContext())
            {

              PaymentList = db.Payment.Where(x => x.CurrencyCode == input).ToList();
            }
            return PaymentList;
        }

        public List<Payment> GetAllbyDateRange(string startdate ,string enddate)
        {
            List<Payment> PaymentList;
            List<Payment> PaymentListFilterdByDateRange = new List<Payment>(); ;
            Payment payment = new Payment();
            using (var db = new PaymentContext())
            {

                PaymentList = db.Payment.ToList();
                foreach (var i in PaymentList)
                {
                    DateTime dateTransaction = DateTime.ParseExact(i.TransactionDate,"yyyy-MM-dd HH:mm tt",System.Globalization.CultureInfo.InvariantCulture);
                    DateTime startdate1 = DateTime.ParseExact(startdate, "yyyy-MM-dd HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime enddate1 = DateTime.ParseExact(enddate, "yyyy-MM-dd HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                    if (dateTransaction >= startdate1 && dateTransaction <= enddate1)
                    {
                        payment = null;
                        payment.CurrencyCode = i.CurrencyCode;
                        payment.Amount = i.Amount;
                        payment.TransactionDate = i.TransactionDate;
                        payment.Status = i.Status;
                        PaymentListFilterdByDateRange.Add(payment);
                    }

                }
            }
            return PaymentListFilterdByDateRange;
        }

        public List<Payment> GetAllbyStatus(string input)
        {
            List<Payment> PaymentList;
            using (var db = new PaymentContext())
            {

                PaymentList = db.Payment.Where(x => x.Status == input).ToList();
            }
            return PaymentList;
        }

        public bool UpdateDatabase(Payment payment)
        {
            using (var context = new PaymentContext())
            {
                context.Add(payment);
                context.SaveChanges();
            }
            return true;
        }
        
    }
}
