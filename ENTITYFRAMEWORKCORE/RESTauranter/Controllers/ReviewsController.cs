using Microsoft.EntityFrameworkCore;
using RESTauranter.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// Other usings

namespace RESTauranter.Controllers
{
    public class ReviewsController : Controller
    {
        private ReviewsContext _context;

        public ReviewsController(ReviewsContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // List<Reviews> AllUsers = _context.Reviews.ToList();
            return View();
            // Other code
        }

        [HttpGet]
        [Route("Reviews")]
        public IActionResult Reviews()
        {
            // var ShowReviews = _context.Reviews.ToList();
            List<RegisterViewModels> AllReviews = _context.Reviews.ToList();
            AllReviews.OrderByDescending(i => i.DateOfVisit);
            ViewBag.AllReviews = AllReviews;
            return View();
        }

        [HttpPost]
        [Route("AddReview")]

        public IActionResult AddReview(RegisterViewModels NewReview)
        {
            if (ModelState.IsValid)
            {
                _context.Reviews.Add(NewReview);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            return View("Index");
        }
    }
}

