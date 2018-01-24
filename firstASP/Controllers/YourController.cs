using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class YourController : Controller
    {
        [HttpGet]
        [Route("displayInt")]
        public JsonResult DisplayInt()
        {
            return Json(34);
        }
        [HttpGet("displayhuman")]
        public JsonResult DisplayHuman()
        {
            var Human = new { name = "Cuong"};
            return Json(Human);
        }
        // public JsonResult Example()
        // {
        //     // The Json method convert the object passed to it into JSON
        //     return Json(SomeC#Object);
        // }
    }
}
