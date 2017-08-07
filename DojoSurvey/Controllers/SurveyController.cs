using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Save(string name, int location, int language, string comments)
        {
            var result = new
            {
                name = name,
                location = location,
                language = language,
                comments = comments
            };
            // HttpContext.Session.SetString("result", JsonConvert.SerializeObject(result));

            TempData["name"] = result.name;
            TempData["location"] = result.location;
            TempData["language"] = result.language;
            TempData["comments"] = result.comments;
            return RedirectToAction("Result");
            // return View();
        }

        public IActionResult Result()
        {

            ViewBag.name = TempData["name"];
            ViewBag.location = TempData["location"];
            ViewBag.language = TempData["language"];
            ViewBag.comments = TempData["comments"];
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
