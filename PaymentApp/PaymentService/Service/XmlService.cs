using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PaymentService.Interface;
using PaymentService.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;

namespace PaymentService.Service
{
    public class XmlService : IXml
    {
        public XmlService()
        {

        }
        public bool Xml(IFormFile file)
        {

            if (file != null) { 
                HttpClient httpClient = new HttpClient();
            try
            {
                var filePath = file.FileName.ToString();
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                    fileStream.Dispose();
                    XDocument xDoc = XDocument.Load(filePath);
                    List<PaymentXML> List = xDoc.Descendants("Transaction").Select(x =>
                   new PaymentXML
                   {
                       TransactionIdentificator = x.Element("Transaction Id").Value,

                       CurrencyCode = x.Element("CurrencyCode").Value,
                       Amount = x.Element("Amount").Value,
                       TransactionDate = x.Element("TransactionIdentificator").Value,
                       Status = x.Element("TransactionIdentificator").Value,

                   }).ToList();
                    String json = JsonConvert.SerializeObject(List);
                    var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                    var postRes = httpClient.PostAsync("https://localhost:44364/api/PaymentAPI", content).Result;

                }
                    return true;
            }
            catch (Exception e)
            {

                return false;
            }
            }
             else {
                return false;
             }

        }

    }
}
