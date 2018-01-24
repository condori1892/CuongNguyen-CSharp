
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace Cuongspace.Controllers
{
    public class PortfolioController : Controller
    {
        [HttpGet("home")]
        public IActionResult Home()
        {
            return View("Home");
        }
        [HttpGet("projects")]
        public IActionResult Pojects()
        {
            return View("Projects");
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View("Contact");
        }
    }
}