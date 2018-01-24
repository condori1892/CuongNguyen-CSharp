using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {
        // Inside your Controller class
        // Other code
        
        // A GET method
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // return View();
            return View("Index");
        }
        
        // A POST method
        // [HttpPost]
        // [Route("")]
        // public IActionResult Other()
        // {
        //     // Return a view (We'll learn how soon!)
        // }

        // [HttpGetAttribute]
        // public string Index()
        // {
        //     return "Hello World!";
        // }
    }
}
