using Administration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Administration.Controllers
{
    public class FacturaController : Controller
    {
        private static string _baseurl;
        public FacturaController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public IActionResult Index()
        {
            List<Factura> factura = new List<Factura>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            var request = client.GetAsync("api/Factura/GetInvoicesList").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                factura = JsonConvert.DeserializeObject<List<Factura>>(resultString);
                return View(factura);
            }

            return View(factura);
        }
        public IActionResult Create()
        {
            List<Factura> factura = new List<Factura>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            var request = client.GetAsync("api/Factura/GetInvoicesList").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                factura = JsonConvert.DeserializeObject<List<Factura>>(resultString);
                return View(factura);
            }

            return View(factura);
        }
        public IActionResult Detalle(int id)
        {
            FacturaCompletaVm factura = new FacturaCompletaVm();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            var request = client.GetAsync("api/Factura/"+ id).Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                factura = JsonConvert.DeserializeObject<FacturaCompletaVm>(resultString);
                return View(factura);
            }

            return View(factura);
       
        }
    }
}
