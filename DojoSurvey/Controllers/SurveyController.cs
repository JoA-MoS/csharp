using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace DojoSurvey.Controllers
{
    public class SurveyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult Save(string name, int location, int language, string comments)
        {
            var result = new
            {
                name = name,
                location = location,
                language = language,
                comments = comments
            };

            // HttpContext.Session.Set("result", JsonConvert.SerializeObject)
            return Json(result);
            // return View();
        }

        public string Result()
        {

            return "result";
            // return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
