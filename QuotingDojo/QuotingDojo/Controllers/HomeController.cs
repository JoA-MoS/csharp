using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuotingDojo.Models;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Quotes()
        {
            var results = new List<Dictionary<string, object>>();
            WebRequest.GetQuoteDataAsync(ApiResponse =>
            {
                results = ApiResponse;
            }
            ).Wait();
            List<UserQuote> quotes = UserQuote.ConvertListOfDictionaries(results);
            System.Console.WriteLine(JsonConvert.SerializeObject(quotes));
            ViewBag.quotes = quotes;
            return View();
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult NewQuote()
        {
            var results = new List<Dictionary<string, object>>();
            WebRequest.GetQuoteDataAsync(ApiResponse =>
            {
                results = ApiResponse;
            }
            ).Wait();
            List<UserQuote> quotes = UserQuote.ConvertListOfDictionaries(results);
            System.Console.WriteLine(JsonConvert.SerializeObject(quotes));
            ViewBag.quotes = quotes;


            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
