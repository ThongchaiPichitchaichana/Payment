using PaymentAPIService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentAPIService.Interface
{
    public interface IPaymentDisplayOutput
    {
        List<PaymentDisplayOutput> GetPaymentDisplayOutputs();
    }
}
