using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
namespace TimeDisplay.Controllers
{
    public class DateTimeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //DateTime.Now
            return View();
        }
    }
}
