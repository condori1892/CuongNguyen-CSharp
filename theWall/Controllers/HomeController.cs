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
            AllClasses model = new AllClasses();
            if(HttpContext.Session.GetInt32("id") == null)
                return View(model);

            return View("Dashboard", model);
            
        }

        [HttpPost("create")]
        public IActionResult Create(AllClasses model)
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
                
                string createUser = $@"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at)
                    VALUES ('{user.first_name}', '{user.last_name}', '{user.email}', '{hashedPW}', NOW(), NOW());";
                DbConnector.Execute(createUser);
                TempData["success"] = "You have successfully registered, you may now log in";
                // return RedirectToAction("LoginView");
                // return View("Success");
            }
            // return View("Index");
            return View("Index", model);
        }

        [HttpPost("login")]
        public IActionResult Login(AllClasses model)
        {
            LogUser user = model.loginUser;

            Dictionary<string, object> userToLog = new Dictionary<string, object>();
            if(ModelState.IsValid)
            {
                string checkEmail = $"SELECT id, password FROM users WHERE email = '{user.log_email}'";
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
                // TempData["success"] = "Thank you for logging in!";
                return RedirectToAction("dashboard", model);
                // return View("Dashboard", model);
            }
            // model.Users = DbConnector.Query("SELECT * FROM users");
            return View("Index", model);
        
            // return View("Success", model);
        }
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            
            if(HttpContext.Session.GetInt32("id") == null)
                return View("Index");
            string all = $@"SELECT users.first_name, users.last_name, messages.message, messages.created_at AS mCreated, comments.comment, comments.created_at AS cCreated 
            FROM messages 
            INNER JOIN users ON users.id = messages.users_id 
            INNER JOIN comment ON messages.id = comments.messages_id 
            ORDER BY messages.created_at DESC";

            // List<Dictionary<string, object>> userToLog = new List<Dictionary<string, object>>();
            // userToLog = DbConnector.Query("SELECT users.first_name, users.last_name, messages.message, messages.created_at FROM users LEFT JOIN messages ON users.id = messages.users_id ORDER BY messages.created_at DESC");
            AllClasses dashboardModel = new AllClasses()
            {
                 allMessages = DbConnector.Query("SELECT users.first_name, users.last_name, messages.id, messages.message, messages.created_at FROM users INNER JOIN messages ON users.id = messages.users_id ORDER BY messages.created_at DESC")
            };
            
            // return View("Success", dashboardModel);
            return View("Dashboard", dashboardModel);
        }

        [HttpGet("logoff")]
        public IActionResult LogOff(AllClasses model)
        {
            HttpContext.Session.Clear();
            return View("Index", model);
        }
        [HttpPost("createMessage")]
        public IActionResult CreateMessage(Message model)
        {
            // Message incomingMessage = model.newMessage;
            if(ModelState.IsValid)
            {
                int? id = HttpContext.Session.GetInt32("id");
                string query = $@"INSERT INTO messages (users_id, message, created_at, updated_at) 
                VALUES ('{id}', '{model.message}', NOW(), NOW())";
                DbConnector.Execute(query);
            }
            AllClasses dashboardModel = new AllClasses()
            {
                 allMessages = DbConnector.Query("SELECT users.first_name, users.last_name, messages.id, messages.message, messages.created_at FROM users INNER JOIN messages ON users.id = messages.users_id ORDER BY messages.created_at DESC"),
                newMessage = model
            };
            if(!ModelState.IsValid)
                return View("Dashboard", dashboardModel);

            return View("Success", dashboardModel);
            // return RedirectToAction("Dashboard");
        }
        [HttpPost("createComment")]
        public IActionResult CreateComment(Comment model)
        {
            // Message incomingMessage = model.newMessage;
            if(ModelState.IsValid)
            {
            int? u_id = HttpContext.Session.GetInt32("id");
            
            string query = $@"INSERT INTO comments (users_id, messages_id, comment, created_at, updated_at) VALUES ('{u_id}', '{model.messages_id}', '{model.comment}', NOW(), NOW())";
            DbConnector.Execute(query);
            }
            AllClasses dashboardModel = new AllClasses()
            {
                 allMessages = DbConnector.Query("SELECT users.first_name, users.last_name, messages.id, messages.message, messages.created_at FROM users INNER JOIN messages ON users.id = messages.users_id ORDER BY messages.created_at DESC"),
                newComment = model
            };
            // if(!ModelState.IsValid)
            //     return View("Dashboard", dashboardModel);

            return View("Success", dashboardModel);
            // return RedirectToAction("Dashboard");
        }


    }
}
