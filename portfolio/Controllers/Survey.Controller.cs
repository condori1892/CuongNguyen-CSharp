using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace Cuongspace.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("result")]
        public IActionResult Result(string name, string location, string language, string comment)
        {
            // ViewBag.infor = new {
            //     Name = name,
            //     Location = location,
            //     Language = language,
            //     Comment = comment
            // };
            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Language = language;
            ViewBag.Comment = comment;
            return View();
        }
        
    }
}