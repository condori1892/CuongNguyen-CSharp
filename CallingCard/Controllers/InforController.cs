using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace Cuongspace.Controllers
{
    public class InforController : Controller
    {
        [HttpGet("{f_name}/{l_name}/{a}/{fav_color}")]
        public JsonResult DisplayInfor(string f_name, string l_name, int a, string fav_color)
        {
            var person_infor = new {
                FirstName = f_name,
                LastName = l_name,
                Age = a,
                FavoriteColor = fav_color
            
            };
            return Json(person_infor);
        }
    }
}