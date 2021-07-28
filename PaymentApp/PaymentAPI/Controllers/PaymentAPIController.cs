using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Interface;
using PaymentAPI.Models;
using PaymentAPI.Service;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentAPIController : ControllerBase
    {
        IPaymentDisplayOutput _paymentDisplayOutput;
        IPaymentDatabase _paymentDatabase;
        public PaymentAPIController(IPaymentDisplayOutput paymentDisplayOutput, IPaymentDatabase paymentDatabase)
        {
            _paymentDisplayOutput = paymentDisplayOutput;
            _paymentDatabase = paymentDatabase;
        }
        // GET api/PaymentAPI
        [HttpGet]
        public ActionResult<List<PaymentDisplayOutput>> Get()
        {
           
            return _paymentDisplayOutput.GetPaymentDisplayOutputs();
        }

       

        // POST api/PaymentAPI
        [HttpPost]
        public bool Post([FromBody] Payment payment)
        {
          
           return _paymentDatabase.UpdateDatabase(payment);
        }

        // GET api/PaymentAPI/CurrencyCode?CurrencyCode="TH"
        [HttpGet("{CurrencyCode}")]
        public List<Payment> GetAllbyCurrencyCode(string CurrencyCode)
        {
            return _paymentDatabase.GetAllbyCurrency(CurrencyCode);
        }
        // GET api/PaymentAPI/Status?Status="Approved"
        [HttpGet("{Status}")]
        public List<Payment> GetAllbyStatus(string Status)
        {
            return _paymentDatabase.GetAllbyStatus(Status);
        }
        //api/PaymentAPI/GetAllbyDateRange?enddate="12/01/2009 12:33:16"&startdate=19/01/2009 12:33:16
        [HttpGet("GetAllbyDateRange")]
        public List<Payment> GetAllbyDateRange(string startdate , string enddate)
        {
            return _paymentDatabase.GetAllbyDateRange(startdate, enddate);
        }
    }
}
