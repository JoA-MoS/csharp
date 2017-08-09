using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;


using Newtonsoft.Json;
using Dojodachi.Models;

namespace Dojodachi.Controllers
{
    public class DojodachiController : Controller
    {

        DojodachiPet pet = new DojodachiPet();


        private DojodachiPet GetDojodachiPetFromSession()
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("pet")))
            {
                pet = new DojodachiPet();
            }
            else
            {
                pet = new DojodachiPet(HttpContext.Session.GetObjectFromJson<DojodachiPet>("pet"));
            }
            pet.Death += (sender, e) => CreateAlert(sender, e, "Dojodachi Died! :-(");
            pet.DidNotEat += (sender, e) => CreateAlert(sender, e, "Dojodachi did not eat :-(");
            pet.DidNotPlay += (sender, e) => CreateAlert(sender, e, "Dojodachi did not play :-(");
            pet.Won += (sender, e) => CreateAlert(sender, e, "Dojodachi WON! :-D");
            return pet;
        }

        private void SaveDojodachiPetToSession()
        {
            HttpContext.Session.SetObjectAsJson("pet", pet);
        }

        public IActionResult Index()
        {
            GetDojodachiPetFromSession();
            ViewBag.pet = pet;
            ViewBag.petJson = JsonConvert.SerializeObject(pet);
            return View();
        }

        [Route("feed")]
        public IActionResult Feed()
        {
            GetDojodachiPetFromSession();
            pet.Feed();
            SaveDojodachiPetToSession();
            return RedirectToAction("Index");
        }
        [Route("play")]
        public IActionResult Play()
        {
            GetDojodachiPetFromSession();
            pet.Play();
            SaveDojodachiPetToSession();
            return RedirectToAction("Index");
        }
        [Route("work")]
        public IActionResult Work()
        {
            GetDojodachiPetFromSession();
            pet.Work();
            SaveDojodachiPetToSession();
            return RedirectToAction("Index");
        }
        [Route("sleep")]
        public IActionResult Sleep()
        {
            GetDojodachiPetFromSession();
            pet.Sleep();
            SaveDojodachiPetToSession();
            return RedirectToAction("Index");
        }
        [Route("restart")]
        public IActionResult Restart()
        {
            // GetDojodachiPetFromSession();
            pet = new DojodachiPet();
            SaveDojodachiPetToSession();
            return RedirectToAction("Index");
        }

        public ActionResult ModalAction(int Id)
        {
            ViewBag.Id = Id;
            return PartialView("ModalContent");
        }

        private void CreateAlert(object sender, EventArgs e, string msg)
        {
            Console.WriteLine("Event Raised!");
            TempData.Add("alert", msg);
            ModalAction(1);
        }
    }
}
