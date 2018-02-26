using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using theWall.Models;
using DbConnection;
using Microsoft.AspNetCore.Identity;

namespace theWall.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        [HttpGet("")]
        public IActionResult Index()
        {
            
            if(HttpContext.Session.GetInt32("id") == null)
                return View(new LogRegModel());

            // // return View("Index", "Dashboard");
            // return View("Success");
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost("create")]
        public IActionResult Create(LogRegModel model)
        {
            User user = model.newUser;
            if(ModelState.IsValid)
            {
                if(user.first_name == user.last_name)
                    ModelState.AddModelError("last_name", "The last name cannot be the same as the first name.");
            }
            if(ModelState.IsValid)
            {
                string check_email = $"SELECT id FROM users WHERE email = '{user.email}'";
                if(DbConnector.Query(check_email).Count > 0)
                {
                    ModelState.AddModelError("email", "Email already in use");
                }
            }
            
            if(ModelState.IsValid)
            {
                // Hash user's password for DB storage
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                string hashedPW = hasher.HashPassword(user, user.password);
                
                string createUser = $@"INSERT INTO users (first_name, last_name, email, password,
                created_at, updated_at) 
                VALUES ('{user.first_name}', '{user.last_name}', '{user.email}', '{hashedPW}', 
                NOW(), NOW());";
                DbConnector.Execute(createUser);

                TempData["success"] = "You have successfully registered, you may now log in";
                
            }
            // return RedirectToAction("Index");
            return View("Index", model);
        }

        [HttpPost("login")]
        public IActionResult Login(LogRegModel model)
        {
            LogUser user = model.loginUser;

            Dictionary<string, object> userToLog = new Dictionary<string, object>();
            if(ModelState.IsValid)
            {
                string checkEmail = $"SELECT id, first_name, password FROM users WHERE email = '{user.log_email}'";
                userToLog = DbConnector.Query(checkEmail).FirstOrDefault();

                if(userToLog == null)
                {
                    ModelState.AddModelError("log_email", "Invalid Email/Password!");
                }
                else
                {
                    // check hashed password for user with email
                    string hashedPW = (string)userToLog["password"];
                    PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
                    // if VerifyHashedPassword evaluates to 0, we have a fail!
                    if(hasher.VerifyHashedPassword(user, hashedPW, user.log_password) == 
                        PasswordVerificationResult.Failed)
                    {
                        ModelState.AddModelError("log_email", "Invalid Email/Password!");
                    }
                }
            }
            
            if(ModelState.IsValid)
            {
                // log user in!
                HttpContext.Session.SetInt32("id", (int)userToLog["id"]);
                HttpContext.Session.SetString("name", (string)userToLog["first_name"]);
                // ViewBag.userName = (string)userToLog["first_name"];
                
                return RedirectToAction("Index", "Dashboard");
                
            }
            
        
            return View("Index", model);
        }
        [HttpGet("logoff")]
        public IActionResult LogOff()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}
