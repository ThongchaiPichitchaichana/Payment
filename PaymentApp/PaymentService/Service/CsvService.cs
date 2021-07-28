using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaymentService.Interface;
using PaymentService.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace PaymentService.Service
{
    public class CsvService : Icsv
    {
        public CsvService()
        {

        }
        public bool CSV(IFormFile file)
        {
            HttpClient httpClient = new HttpClient();
            if (file != null)
            {
                    try
                    {
                        using (var reader = new StreamReader(file.OpenReadStream()))
                        {


                            using (var csv = new CsvReader(reader))
                            {
                                csv.Configuration.RegisterClassMap<PaymentMap>();
                                var records = csv.GetRecords<Payment>().ToList();
                                String json = JsonConvert.SerializeObject(records);
                                var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
                                var postRes = httpClient.PostAsync("https://localhost:44364/api/PaymentAPI", content).Result;
                            return true;
                        }
                        }
                    }
                    catch (Exception e)
                    {
                    return false;
                     }

                return true;
            }else
            {
                return false;
            }
        }

    }
}
