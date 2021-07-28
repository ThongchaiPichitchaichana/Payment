using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentService.Interface
{
    public interface IPaymentService
    {
       bool ProcessCSV(IFormFile file);

       bool ProcessXml(IFormFile file);
       
    }
}
