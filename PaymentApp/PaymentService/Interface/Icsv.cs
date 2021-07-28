using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentService.Interface
{
    public interface Icsv
    {
        bool CSV(IFormFile file);
       
    }
}
