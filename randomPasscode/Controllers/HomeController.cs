using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace randomPasscode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {  
            return View();
        }
        [HttpGet("generate")]
        public IActionResult Generate()
        {
            Random rand = new Random();
            string randomString = "";
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            for(int i = 1; i <= 14; i++)
            {
                randomString += chars[rand.Next(34)].ToString();

            }
            TempData["passcode"] = randomString;
            int? counter = HttpContext.Session.GetInt32("counter");
            if(counter == null)
                counter = 0;
            counter++;
            TempData["counter"] = counter;
            HttpContext.Session.SetInt32("counter", (int)counter);
            // HttpContext.Session.SetString("passcode", randomString);
            // HttpContext.Session.SetInt32("counter", 0);
            return RedirectToAction("Index");
        }


    }
}
