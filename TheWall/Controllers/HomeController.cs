using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheWall.Models;
using TheWall.Models.TheWallViewModels;
using TheWall.Data;

namespace TheWall.Controllers
{

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public HomeController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Messages()
        {
            // ViewBag.Messages = _context.Messages;
            foreach (Message message in _context.Messages)
            {
                System.Console.WriteLine(message.User.FirstName);
            }
            // System.Console.WriteLine(_context.Messages);
            return View(_context.Messages.ToList());
        }

        [HttpPost]
        public IActionResult PostMessage([FromForm] MessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                Message message = new Message
                {
                    MessageText = model.MessageText,
                    UserId = userId,
                };

                _context.Messages.Add(message);
                _context.SaveChanges();



            }
            return RedirectToAction("Index");


        }



        public IActionResult Error()
        {
            return View();
        }
    }
}
