using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentApp2.Models;
using PaymentService.Interface;
using PaymentService.Service;

namespace PaymentApp2.Controllers
{
    public class HomeController : Controller
    {
        IPaymentService _PaymentService;
        public HomeController(IPaymentService paymentService)
        {
            _PaymentService = paymentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult UploadFile([FromForm]IFormFile file)
        {
           // _PaymentService = new PaymentService.Service.PaymentService();
            var ext = Path.GetExtension(file.FileName);
            if (ext.ToString() == ".csv")
            {

                bool result = _PaymentService.ProcessCSV(file);
                if (result)
                {
                    return Ok("insert data successfully");
                }
                else
                {
                    return BadRequest("fail to insert data as invalid column for csv file");
                }

            }
            else if (ext.ToString() == ".xml")
            {
                bool resultXml = _PaymentService.ProcessXml(file);

                if (resultXml)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("invalid column in xml file");
                }
            }
            else
            {

                return BadRequest("invalid or unknown file format");
            }


        }


    }
}
