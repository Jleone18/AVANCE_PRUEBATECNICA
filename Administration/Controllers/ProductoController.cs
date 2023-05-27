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
    public class ProductoController : Controller
    {
        private static string _baseurl;
        public ProductoController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public IActionResult Index()
        {
            List<ProductVm> producto = new List<ProductVm>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            var request = client.GetAsync("api/Producto/GetProductsList").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                producto = JsonConvert.DeserializeObject<List<ProductVm>>(resultString);
                return View(producto);
            }

            return View(producto);
        }
        public IActionResult Create()
        {
            ProductVm producto = new ProductVm();

            return PartialView("_ProductoModelPartial", producto);
        }
        public IActionResult BuscarModal()
        {


            return PartialView("_ListaProductosPartial");
        }

        [HttpPost]
        public IActionResult Create(ProductVm producto)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var request = client.PostAsync("api/Producto/", producto, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<long>(resultString);
                if (!result.Equals(0))
                {
                    return RedirectToAction("Index");
                }
                return View(producto);
            }

            return PartialView("_ProductoModelPartial", producto);


        }
        [HttpGet]
        public ActionResult<object> GetProductoByNombre(string parametro)
        {
            List<ProductoVm> producto = new List<ProductoVm>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            var request = client.GetAsync("api/Producto/" + parametro).Result;

            var resultString = request.Content.ReadAsStringAsync().Result;
            producto = JsonConvert.DeserializeObject<List<ProductoVm>>(resultString);



            object json = new { data = producto };

            return json;
        }
    }
}
