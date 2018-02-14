using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using System.ComponentModel.DataAnnotations;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("quotes")]
        public IActionResult Quote()
        {
            return View();
        }

        [HttpPost("quotes")]
        public IActionResult Create(Quote quote)
        {
            // if(quote.name.Length == 0)
            //     TempData["nameError"] = "Name field is required";
            
            // if(quote.name.Length < 2)
            //     TempData["nameError"] = "Name must be at least 2 chars";

            // if(quote.quote.Length == 0)
            //     TempData["quoteError"] = "Quote field is required";
            
            // if(quote.quote.Length < 15)
            //     TempData["quoteError"] = "Quote must be at least 15 chars";
    
            if(ModelState.IsValid)
            {
                return RedirectToAction("Quote");

            }
            // if(ModelState.IsValid && newquote.Length > 15)
            // {
            //     return RedirectToAction("Quote");

            // }
            // TryValidateModel(quote);
            // TempData["error"] = "Quote must be at least 15 chars";
            // return View();
            return View("Index");
            // return RedirectToAction("Index");
        }

    }
}
