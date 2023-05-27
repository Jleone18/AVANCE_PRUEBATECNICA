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
    public class CategoriaController : Controller
    {
        private static string _baseurl;
        public CategoriaController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:baseUrl").Value;
        }
        public IActionResult Index()
        {
            List<CategoriaVm> categoria = new List<CategoriaVm>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            var request = client.GetAsync("api/Categoria/GetCategoriesList").Result;
            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                categoria = JsonConvert.DeserializeObject<List<CategoriaVm>>(resultString);
                return View(categoria);
            }

            return View(categoria);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
