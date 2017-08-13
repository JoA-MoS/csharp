using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheWall.Data;
using TheWall.Models;
using TheWall.Models.TheWallViewModels;

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
            ViewBag.messages = _context.Messages.Include(m => m.User)
                .Include(m => m.Comments).ToList();
            return View();
        }
        [Authorize]
        public IActionResult Messages()
        {
            var msgs = _context.Messages.Include(m => m.User).ToList();
            // foreach (Message message in msgs)
            // {
            //     System.Console.WriteLine(message.User.FirstName);
            // }
            // System.Console.WriteLine(_context.Messages);
            return View(msgs);
        }

        [HttpPost]
        [Authorize]
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

        [HttpPost]
        [Route("{messageId}/comments")]
        public IActionResult PostComment([FromForm] CommentViewModel model, int messageId)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                Comment comment = new Comment
                {
                    CommentText = model.CommentText,
                    UserId = userId,
                    MessageId = messageId
                };

                _context.Comments.Add(comment);
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
