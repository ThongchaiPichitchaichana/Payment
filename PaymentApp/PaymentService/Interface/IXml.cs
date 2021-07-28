using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentService.Interface
{
   public interface IXml
    {
        bool Xml(IFormFile file);
    }
}
