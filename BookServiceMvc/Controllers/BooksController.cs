using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookServiceMvc.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public T GetApiResult<T>(string uri)
        {
            using (HttpClient httpClient = new HttpClient()) 
            { 
                Task<String> response = httpClient.GetStringAsync(uri); 
                return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(response.Result)).Result; 
            } 
        }
    }
}