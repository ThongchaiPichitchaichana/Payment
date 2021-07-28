using Microsoft.AspNetCore.Http;
using PaymentService.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentService.Service
{
    public class PaymentService : IPaymentService
    {
        PaymentCSVBusinessLogic _PaymentCSVBusinessLogic;
        PaymentXmlBusinessLogic _paymentXmlBusinessLogic;
        public PaymentService()
        {
            _PaymentCSVBusinessLogic = new PaymentCSVBusinessLogic(new CsvService());
            _paymentXmlBusinessLogic = new PaymentXmlBusinessLogic(new XmlService());
        }
        public bool ProcessCSV(IFormFile file)
        {
            return _PaymentCSVBusinessLogic.ProcessCSV(file);
        }
        public bool ProcessXml(IFormFile file)
        {
            return _paymentXmlBusinessLogic.ProcessXml(file);
        }
    }
}
