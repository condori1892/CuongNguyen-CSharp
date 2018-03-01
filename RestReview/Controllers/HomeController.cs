using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestReview.Models;
using Microsoft.EntityFrameworkCore;


namespace RestReview.Controllers
{
    
    public class HomeController : Controller
    {
        private RestaurantContext _context;
    
        public HomeController(RestaurantContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("create")]
        public IActionResult Create(Review newReview)
        {
            if(newReview.visited_date > DateTime.Now)
                ModelState.AddModelError("visited_date", "Check visited date");
            if(ModelState.IsValid)
            {
                _context.reviews.Add(newReview);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }

            return View("Index", newReview);
        }

        [HttpGet("reviews")]
        public IActionResult Reviews()
        {
            ViewBag.reviews = _context.reviews.OrderByDescending(t => t.visited_date).ToList();
            return View();

        }

        
    }
}
