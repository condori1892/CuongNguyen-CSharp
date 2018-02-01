using System;

namespace SeshExtend
{
    public static class Extensions
    {
        public static string FormattedString(this DateTime dateTime)
        {
            return dateTime.ToString("g");
        }
    }   
}

using System;
using Newtonsoft.Json;
namespace SeshExtend
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(now.FormattedString());

            string formetted = JsonConvert.SerializeObject(now);
            DateTime backAgain = JsonConvert.DeserializeObject<DateTime>(formetted);

            Console.WriteLine(backAgain.FormattedString());
        }
    }
}

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace Session600
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectAsJson<T>(this ISession session, string key)
        {
            string val = session.GetString(key);
            return val == null ? default(T) : JsonConvert.DeserializeObject<T>(val);
        }
    }
}

//************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session600.Models;

namespace Session600.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            // check if id is in session
            if(HttpContext.Session.GetInt32("id") == null)
            {
                HttpContext.Session.SetInt32("id", 0);
            }

            ViewBag.Count = HttpContext.Session.GetInt32("id");
            return View();
        }
        [HttpGet("counter")]
        public IActionResult Counter()
        {
            int count = (int)HttpContext.Session.GetInt32("id");
            HttpContext.Session.SetInt32("id", ++count);
            return RedirectToAction("Index");
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Session600.Models;

namespace Session600.Controllers
{
    public class NinjaController : Controller
    {
        [HttpGet("gold")]
        public IActionResult Index()
        {
            // check if id is in session
            if(HttpContext.Session.GetObjectAsJson<Golding>("game") == null)
            {
                HttpContext.Session.SetObjectAsJson("game", new Golding());
            }

            ViewBag.Game = HttpContext.Session.GetObjectAsJson<Golding>("game");
            return View();
        }
        [HttpPost("process")]
        public IActionResult Process(string building)
        {
            Random rand = new Random();
            string action = "earn";
            int goldThisTime = 0;
            switch(building)
            {
                case "house":
                    goldThisTime += rand.Next(1,5);
                    break;
                case "farm":
                    goldThisTime += rand.Next(3,14);
                    break;
                case "cave":
                    goldThisTime += rand.Next(6,9);
                    break;
                default:
                    goldThisTime += rand.Next(-30,51);
                    break;
            }
            
            Golding game = HttpContext.Session.GetObjectAsJson<Golding>("game");
            
            action = goldThisTime < 0 ? "lose" : action;
            game.Gold += goldThisTime;
            game.Activities.Add(
                $"You {action} {goldThisTime} from the {building} ({DateTime.Now.ToString("g")})"
            );

            HttpContext.Session.SetObjectAsJson("game", game);
            return RedirectToAction("Index");
        }
        
    }
}
using System.Collections.Generic;

namespace Session600
{
    public class Golding
    {
        public int Gold;
        public List<string> Activities;
        public Golding()
        {
            Gold = 0;
            Activities = new List<string>();
        }
    }
}
<input type="text" value="@ViewBag.Game.Gold">
<hr>
<div class="building">
    <h3>House</h3>
    <p>Get 1-4 golds</p>
    <form action="/process" method="post">
        <input type="hidden" name="building" value="house">
        <input type="submit" value="Get Gold">
    </form>
</div>
<div class="building">
    <h3>Cave</h3>
    <p>Get 3-8 golds</p>
    <form action="/process" method="post">
        <input type="hidden" name="building" value="cave">
        <input type="submit" value="Get Gold">
    </form>
</div>
<div class="building">
    <h3>Farm</h3>
    <p>Get 3-14 golds</p>
    <form action="/process" method="post">
        <input type="hidden" name="building" value="farm">
        <input type="submit" value="Get Gold">
    </form>
</div>
<div class="building">
    <h3>Casino</h3>
    <p>Get/Lose 30-50 golds</p>
    <form action="/process" method="post">
        <input type="hidden" name="building" value="casino">
        <input type="submit" value="Get Gold">
    </form>
</div>
<hr>
<div class="activities">
    @foreach(string act in ViewBag.Game.Activities)
    {
        <p>@act</p>
    }
</div>

namespace AspDataFun.Models
{
    public class Player
    {
        public string first_name {get;set;}
        public string last_name {get;set;}
    }
}

// ErrorViewModel.cs
using System;

namespace AspDataFun.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspDataFun.Models;

namespace AspDataFun.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            List<string> Teams = new List<string>()
            {
                "Patriots",
                "Eagles",
                "Dodgers",
                "Mariners"
            };

            ViewBag.Teams = Teams;
            ViewData["Players"] = new List<string>()
            {
                "Dion Sanders",
                "Dan Marino",
                "Randall Cunningham"
            };

            return View();
        }
        [HttpPost("postit")]
        public IActionResult AddTeam(string team_name, string team_city)
        {
            TempData["name"] = team_name;
            TempData["city"] = team_city;
            return RedirectToAction("Index");
        }
        [HttpPost("addplayer")]
        public IActionResult AddPlayer(Player player)
        {
            return Json(player);
        }

    }
}
@{
    ViewData["Title"] = "Home Page";
}
<p>@TempData["name"]</p>
<p>@TempData["city"]</p>
<form action="/postit" method="post">
    <input type="text" name="team_name" placeholder="Team Name:">
    <input type="text" name="team_city" placeholder="Team City:">
    <input type="submit" value="Send Team">
</form>
<hr>
<form action="/addplayer" method="post">
    <input type="text" name="first_name" placeholder="First Name:">
    <input type="text" name="last_name" placeholder="Last Name:">
    <input type="submit" value="Add Player">
</form>
<h2>Here are some teams</h2>
@foreach(string team in ViewBag.Teams)
{
    <p>@team</p>
}
<hr>
<h2>Here are some players</h2>
@foreach(string player in ((List<string>)ViewData["Players"]))
{
    <p>@player</p>
}