using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using randomPasscode.Models;
using Newtonsoft.Json;

namespace randomPasscode.Controllers
{
    public class DojodachiController : Controller
    {
        [HttpGet("dojodachi")]
        public IActionResult Index()
        {  
            if(HttpContext.Session.SetObjectAsJson<Initalize>("game") == null)
            {
                HttpContext.Session.SetObjectAsJson("game", new Initalize());
            }

            ViewBag.Game = HttpContext.Session.GetObjectAsJson<Initalize>("game");
            
            return View();
        }
        
        


    }
}
