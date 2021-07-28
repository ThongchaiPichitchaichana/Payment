using Microsoft.AspNetCore.Http;
using PaymentService.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentService.Service
{
    public class PaymentCSVBusinessLogic
    {
        Icsv _icsv; 
        public PaymentCSVBusinessLogic(Icsv icsv ) {
            _icsv = icsv;
        }
        public PaymentCSVBusinessLogic()
        {
            _icsv = new CsvService();
        }
        public bool ProcessCSV(IFormFile file) {
            return _icsv.CSV(file);
         }
       


    }
}
