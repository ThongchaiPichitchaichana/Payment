
using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentAPI.Interface
{
    public interface IPaymentDisplayOutput
    {
        List<PaymentDisplayOutput> GetPaymentDisplayOutputs();
    }
}
