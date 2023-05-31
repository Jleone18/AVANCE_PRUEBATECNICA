using Administration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
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
            List<FacturaVm> factura = new List<FacturaVm>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            var request = client.GetAsync("api/Factura/GetInvoicesList").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                factura = JsonConvert.DeserializeObject<List<FacturaVm>>(resultString);
                return View(factura);
            }

            return View(factura);
        }
        public IActionResult Create()
        {
            List<FacturaVm> factura = new List<FacturaVm>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            var request = client.GetAsync("api/Factura/GetInvoicesList").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                factura = JsonConvert.DeserializeObject<List<FacturaVm>>(resultString);
                return View(factura);
            }

            return View(factura);
        }
        [HttpPost]
        public IActionResult CreateFactura([FromBody] FacturaCompletaRequestVm factura)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            var request = client.PostAsync("api/Factura/", factura, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<long>(resultString);
                if (!result.Equals(0))
                {
                    return Json(new { respuesta = true });
                }
                return Json(new { respuesta = false });
            }
            

            return Json(new { respuesta = false });
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
