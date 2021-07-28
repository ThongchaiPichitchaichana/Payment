using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Interface
{
    public interface IPaymentDatabase
    {
        bool UpdateDatabase(Payment payment);
        List<Payment> GetAllbyCurrency(string input);
        List<Payment> GetAllbyDateRange(string startdate, string enddate);
        List<Payment> GetAllbyStatus(string input);

    }
}
