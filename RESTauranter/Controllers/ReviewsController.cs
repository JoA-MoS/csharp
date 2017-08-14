using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Data;
using RESTauranter.Models;
using RESTauranter.Models.ReviewViewModels;
using RESTauranter.CustomAttributes;
using Microsoft.EntityFrameworkCore;

namespace RESTauranter.Controllers {
    [Authorize]
    [Route("reviews")]
    public class ReviewsController : Controller {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private ApplicationDbContext _context;
        public ReviewsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context) {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult AllReviews() {
            List<Review> reviews = _context.Reviews
                                            .Include(r => r.Restaurant)
                                            .Include(r => r.CreatedBy)
                                            .OrderByDescending(r => r.Created)
                                            .ToList();
            return View(reviews);
        }

        [HttpGet]
        [Route("create")]
        // [RestoreModelStateFromTempData]
        public IActionResult Create() {
            ReviewViewModel model = new ReviewViewModel();
            ViewBag.restaurants = _context.Restaurants.ToList();
            // TempData["Review"] = model;
            return View();
        }

        [HttpPost]
        [Route("create")]
        // [SetTempDataModelState]
        public IActionResult Create(ReviewViewModel model) {


            if (ModelState.IsValid) {
                // _userManager.GetUserName(User);
                var userId = _userManager.GetUserId(User);
                Review review = new Review {
                    RestaurantId = model.RestaurantId,
                    CreatedById = userId,
                    ReviewText = model.ReviewText,
                    Rating = model.Rating
                };
                _context.Reviews.Add(review);
                _context.SaveChanges();
                System.Console.WriteLine("++++++++++++++++++++VALID+++++++++++++++++++");
                return RedirectToAction("AllReviews");
            }
            System.Console.WriteLine("--------------------NOT VALID--------------------");
            ViewBag.restaurants = _context.Restaurants.ToList();
            return View();
        }
    }
}
