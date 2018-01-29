using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Game1.Models;

namespace Game1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("dojodachi")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetObjectAsJson<Dojodachi>("game") == null)
            {
                HttpContext.Session.SetObjectAsJson("game", new Dojodachi());
            }

            ViewBag.Game = HttpContext.Session.GetObjectAsJson<Dojodachi>("game");
            return View();
        }
        [HttpGet("restart")]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
        [HttpPost("process")]
        public IActionResult Process(string action)
        {
            // Random rand = new Random();
            // string action = "earn";
            // int goldThisTime = 0;
            Dojodachi game = HttpContext.Session.GetObjectAsJson<Dojodachi>("game");
            switch(action)
            {
                case "Feeding":
                    game.Feed();
                    break;

                case "Playing":
                    game.Play();
                   
                    break;
                case "Working":
                    game.Work();
                    
                    break;
                default:
                    game.Sleep();
                    
                    break;
            }
            
            // Golding game = HttpContext.Session.GetObjectAsJson<Golding>("game");
            
            // action = goldThisTime < 0 ? "lose" : action;
            // game.Gold += goldThisTime;
            // game.Activities.Add(
            //     $"You {action} {goldThisTime} from the {building} ({DateTime.Now.ToString("g")})"
            // );
            game.CheckDojodachi();
            HttpContext.Session.SetObjectAsJson("game", game);
            return RedirectToAction("Index");
        }

    }
}
