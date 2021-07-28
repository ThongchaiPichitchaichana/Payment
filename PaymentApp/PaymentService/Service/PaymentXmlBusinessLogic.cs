using Microsoft.AspNetCore.Http;
using PaymentService.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentService.Service
{
    public class PaymentXmlBusinessLogic
    {
        IXml _ixml;
        public PaymentXmlBusinessLogic(IXml ixml ) {
            _ixml = ixml;
        }
        public PaymentXmlBusinessLogic()
        {
            _ixml = new XmlService();
        }
        public bool ProcessXml(IFormFile file) {
            return _ixml.Xml(file);
         }
       


    }
}
