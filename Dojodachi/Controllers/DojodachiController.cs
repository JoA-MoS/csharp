using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;

namespace Dojodachi.Controllers
{
    public class DojodachiController : Controller
    {
        Pet pet = new Pet();
        public IActionResult Index()
        {
            ViewBag.pet = pet;
            return View();
        }


        public IActionResult Feed()
        {
            pet.Feed();
            return RedirectToAction("Index");
        }

        public IActionResult Play()
        {
            pet.Play();
            return View();
        }

        public IActionResult Work()
        {
            pet.Work();
            return View();
        }
        public IActionResult Sleep()
        {
            pet.Sleep();
            return View();
        }
        public IActionResult Restart()
        {
            pet = new Pet();
            return View();
        }
    }
}
