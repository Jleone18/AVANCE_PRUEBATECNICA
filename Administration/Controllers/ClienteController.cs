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
    public class ClienteController : Controller
    {
        private static string _baseurl;
        public ClienteController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public IActionResult Index()
        {
            List< Cliente> cliente = new List<Cliente>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            var request = client.GetAsync("api/Cliente/GetCustomersList").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                cliente = JsonConvert.DeserializeObject<List<Cliente>>(resultString);
                return View(cliente);
            }
          
            return View(cliente);
        }
        public IActionResult Create()
        {
            Cliente cliente = new Cliente();
           
            return  PartialView("_ClienteModelPartial",cliente);
        }
        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var request = client.PostAsync("api/Cliente/", cliente, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<long>(resultString);
                if (!result.Equals(0))
                {
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }

            return PartialView("_ClienteModelPartial", cliente);


        }
        public IActionResult BuscarModal()
        {
           

            return PartialView("_ListaClientesPartial");
        }

        [HttpGet]
        public ActionResult<object> GetCustomerByNombreCedula(string parametro)
        {
            List<Cliente> cliente = new List<Cliente>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            var request = client.GetAsync("api/Cliente/"+ parametro).Result;
          
            var resultString = request.Content.ReadAsStringAsync().Result;
            cliente = JsonConvert.DeserializeObject<List<Cliente>>(resultString);
             
   

            object json = new { data = cliente };

            return json;
        }
    }
}
