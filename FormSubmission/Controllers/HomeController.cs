using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("submit")]
        public IActionResult Submit(Users user)
        {
            if(ModelState.IsValid)
                return View("Success");
            return View("Index");
        }

    }
}
