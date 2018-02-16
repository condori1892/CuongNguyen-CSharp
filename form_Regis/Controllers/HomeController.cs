using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using form_Regis.Models;
using DbConnection;
using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.PasswordHasher;

// using Microsoft.AspNetCore.Identity.Core;

namespace form_Regis.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            // ViewBag.message = "Register";
            if(HttpContext.Session.GetString("email") == null)
                return View();
            return RedirectToAction("Success");
        }
        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                // PasswordHasher<User> hashedPassword = new PasswordHasher<User>();
                string query = $@"INSERT INTO user (first_name, last_name, email, password, created_at, updated_at) 
                VALUES ('{newUser.first_name}', '{newUser.last_name}', '{newUser.email}', '{newUser.password}', NOW(), NOW())";
                DbConnector.Execute(query);
                ViewBag.message = "Successful! Login, Please!";
                // HttpContext.Session.SetString("email", newUser.email);
                // return RedirectToAction("Success");
                // return RedirectToAction("Index");
                return View("Index");
            }
            
            return View("Index");
        }
        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            string query = $@"SELECT * FROM user WHERE email = '{email}'";
            if(DbConnector.Query(query).Count() > 0)
            {
                if(DbConnector.Query($"SELECT * FROM user WHERE password = '{password}'").Count() > 0)
                {
                    HttpContext.Session.SetString("email", email);
                    return RedirectToAction("Success");
                }
                else
                {
                    ViewBag.login = "Check your Password!";
                    return View("Index");
                    
                }
            }
            else
            {
                ViewBag.login = "Email is not matching!";
                return View("Index");

            }
            // if(ModelState.IsValid)
            // {
            //     HttpContext.Session.SetString("email", email);
            //     return View("Success");
            // }
            // return RedirectToAction("Index");
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            if(HttpContext.Session.GetString("email") == null)
                return View("Index");
            string query = "SELECT * FROM user";
            ViewBag.users = DbConnector.Query(query);
            return View("Success");
        }
        [HttpGet("quote")]
        public IActionResult Quote()
        {
            return View("Quote");
        }

        [HttpPost("quotes")]
        public IActionResult Create(Quote quote)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Quotes");

            }
            // TryValidateModel(quote);
            ViewBag.errors = ModelState.Values;
            // return View();
            return View("Quote");
            // return RedirectToAction("Index");
        }

    }
}
