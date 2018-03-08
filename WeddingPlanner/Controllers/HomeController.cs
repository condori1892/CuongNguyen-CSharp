using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WeddingPlanner.Models;



namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private WeddingContext _context;
    
        public HomeController(WeddingContext context)
        {
            _context = context;
        }
               [HttpGet("")]

        public IActionResult Index()
        {
            return View("Register", new NewUser());
            // return View("Login", new LoginUser());
        }

        [HttpPost("create")]
        public IActionResult Create(NewUser model)
        {
            if(_context.users.Where(u => u.email == model.email)
                                    .ToList()
                                    .Count() > 0)
            {
                ModelState.AddModelError("email", "Email already exist!");
            }
            if(ModelState.IsValid)
            {    
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                User createUser = new User()
                {
                    first_name = model.first_name,
                    last_name = model.last_name,
                    email = model.email,
                    password = hasher.HashPassword(model, model.password)
                };
                _context.users.Add(createUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("user_id", createUser.user_id);
                return RedirectToAction("Index", "Dashboard");
                // int user_id = (int)HttpContext.Session.GetInt32("user_id");
               
                
                // return Json(createUser);
                // return RedirectToAction("UserAccount", new { id = user_id});
            }
            return View("Register");
        }

        [HttpGet("register")]
        public IActionResult Register()
        {

            if(HttpContext.Session.GetInt32("user_id") == null)
                return View();
            return RedirectToAction("Index", "Dashboard");
            // int id = (int)HttpContext.Session.GetInt32("user_id");
            // return View("Test");
            // return RedirectToAction("Login/id");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            if(HttpContext.Session.GetInt32("user_id") == null)
                return View();
            // int? user_id = (int)HttpContext.Session.GetInt32("user_id");
            return RedirectToAction("Index", "Dashboard");
            // return View("Test");
            // return RedirectToAction("UserAccount", new { id = user_id});  
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser model)
        {
            var check = _context.users.Where(c => c.email == model.logEmail).ToList();
            if(ModelState.IsValid)
            {
                if(_context.users.Where(u => u.email == model.logEmail)
                                        .ToList()
                                        .Count() == 0)
                {
                    ModelState.AddModelError("logEmail", "Invalid Email/Password");
                }
                else
                {
                    User checkUserPW = _context.users.SingleOrDefault(u => u.email == model.logEmail);
                    PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                    if(hasher.VerifyHashedPassword(model, checkUserPW.password, model.logPassword) == PasswordVerificationResult.Failed)
                    {
                        ModelState.AddModelError("logPassword", "Invalid Email/Password!");
                    }
                    else
                    {
                        // User checkUser = _context.users.SingleOrDefault(u => u.email == model.logEmail);
                        HttpContext.Session.SetInt32("user_id", checkUserPW.user_id);
                        // int? user_id = HttpContext.Session.GetInt32("user_id");
                        return RedirectToAction("Index", "Dashboard");
                        // return Json(model);
                        // return RedirectToAction("UserAccount", new { id = user_id});
                        // return View("UserAccount");
                    }
                }
            }
            return View();


        }
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
            
        }






        //******************************************************************* */
        // [HttpGet("")]
        // public IActionResult Index()
        // {
        //     return View(new LogRegModel());
        // }
        // [HttpPost("create")]
        // public IActionResult Create(LogRegModel model)
        // {
        //     User aUser = model.regUser;

        //     if(_context.users.Where(u => u.email == aUser.email)
        //                             .ToList()
        //                             .Count() > 0)
        //     {
        //         ModelState.AddModelError("email", "Email already exist!");
        //         ViewBag.email = "Email already exist!!";
        //     }
        //     if(ModelState.IsValid)
        //     {    
        //         PasswordHasher<User> hasher = new PasswordHasher<User>();
        //         User createUser = new User()
        //         {
        //             first_name = aUser.first_name,
        //             last_name = aUser.last_name,
        //             email = aUser.email,
        //             password = hasher.HashPassword(aUser, aUser.password)
        //         };
        //         _context.users.Add(createUser);
        //         _context.SaveChanges();
        //         HttpContext.Session.SetInt32("user_id", createUser.user_id);
        //         int user_id = (int)HttpContext.Session.GetInt32("user_id");
              
        //         return Json(createUser);
        //         // return RedirectToAction("UserAccount", new { id = user_id});
        //         // return Json(model);
        //     }
        //     return View("Index", model);
        // }

        // // [HttpGet("register")]
        // // public IActionResult Register()
        // // {

        // //     if(HttpContext.Session.GetInt32("user_id") == null)
        // //         return View();
        // //     int id = (int)HttpContext.Session.GetInt32("user_id");
        // //     return RedirectToAction("Login/id");
        // // }

        // // [HttpGet("login")]
        // // public IActionResult Login()
        // // {
        // //     if(HttpContext.Session.GetInt32("user_id") == null)
        // //         return View();
        // //     int? user_id = (int)HttpContext.Session.GetInt32("user_id");
        // //     return RedirectToAction("UserAccount", new { id = user_id});  
        // // }

        // [HttpPost("login")]
        // public IActionResult Login(LogRegModel model)
        // {
        //     LoginUser a_logUser = model.logUser;
        //     var check = _context.users.Where(c => c.email == a_logUser.logEmail).ToList();
        //     if(ModelState.IsValid)
        //     {
        //         if(_context.users.Where(u => u.email == a_logUser.logEmail)
        //                                 .ToList()
        //                                 .Count() == 0)
        //         {
        //             ModelState.AddModelError("logEmail", "Invalid Email/Password");
        //         }
        //         else
        //         {
        //             User checkUserPW = _context.users.SingleOrDefault(u => u.email == a_logUser.logEmail);
        //             PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
        //             if(hasher.VerifyHashedPassword(a_logUser, checkUserPW.password, a_logUser.logPassword) == PasswordVerificationResult.Failed)
        //             {
        //                 ModelState.AddModelError("logPassword", "Invalid Email/Password!");
        //             }
        //             else
        //             {
        //                 // User checkUser = _context.users.SingleOrDefault(u => u.email == model.logEmail);
        //                 HttpContext.Session.SetInt32("user_id", checkUserPW.user_id);
        //                 int? user_id = HttpContext.Session.GetInt32("user_id");
        //                 // return RedirectToAction("UserAccount", new { id = user_id});
        //                 return Json(a_logUser);
        //                 // return View("UserAccount");
        //             }
        //         }

        //     }
            
        //     return View("Index");


        // }

    }
    
}
