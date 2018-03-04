using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BankAccounts.Models;
using System.Text.RegularExpressions;



namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {
        private BankAccountsContext _context;
    
        public HomeController(BankAccountsContext context)
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
                int user_id = (int)HttpContext.Session.GetInt32("user_id");
                Account newAccount = new Account()
                {
                    balance = 0,
                    activity = 0,
                    user_id = user_id
                };
                _context.accounts.Add(newAccount);
                _context.SaveChanges();
                
                // return Json(createUser);
                return RedirectToAction("UserAccount", new { id = user_id});
            }
            return View("Register");
        }

        [HttpGet("register")]
        public IActionResult Register()
        {

            if(HttpContext.Session.GetInt32("user_id") == null)
                return View();
            int id = (int)HttpContext.Session.GetInt32("user_id");
            return RedirectToAction("Login/id");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            if(HttpContext.Session.GetInt32("user_id") == null)
                return View();
            int? user_id = (int)HttpContext.Session.GetInt32("user_id");
            return RedirectToAction("UserAccount", new { id = user_id});  
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
                        int? user_id = HttpContext.Session.GetInt32("user_id");
                        return RedirectToAction("UserAccount", new { id = user_id});
                        // return View("UserAccount");
                    }
                }
            }
            return View();


        }

        [HttpGet("login/{id}")]
        public IActionResult UserAccount(int id)
        {

            if(HttpContext.Session.GetInt32("user_id") == null)
                return RedirectToAction("Index");
            int? user_id = HttpContext.Session.GetInt32("user_id");
            // var model = _context.users.Include(t => t.transaction)
            //                             .Where(u => u.user_id == user_id)
            //                             .ToList()
            //                             .First();
            var model = _context.accounts.Include(u => u.AccountUser)
                                            .Where(i => i.user_id == user_id)
                                            .OrderByDescending(d => d.activity_date)
                                            .ToList();
            
            var model2 = _context.accounts.Include(u => u.AccountUser)
                                            .Where(i => i.user_id == user_id)
                                            .OrderByDescending(d => d.activity_date)
                                            .ToList().First();
            ViewBag.balance = (float)model2.balance;
            ViewBag.username = model2.AccountUser.first_name;
            return View("UserAccount", model);
            // return View("Test", model2);
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
            
        }
        
        

        [HttpPost("action")]
        public IActionResult Action(float number)
        {
            int? user_id = HttpContext.Session.GetInt32("user_id");
            var a = _context.accounts.Where(u => u.user_id == user_id)
                                        .OrderByDescending(d => d.activity_date)
                                        .ToList().First();
            if(a.balance + number <= 0)
            {
                TempData["error"] = "Can not Withdraw";
                return RedirectToAction("UserAccount", new { id = user_id});
            }
            else
            {
                Account newTrans = new Account()
                {
                    balance = a.balance + number,
                    activity = number,
                    user_id = (int)user_id
                };
                _context.accounts.Add(newTrans);
                _context.SaveChanges();
            }
            
            // int? id = HttpContext.Session.GetInt32("user_id");
            // var bankInfor = _context.accounts.Include(u => u.AccountUser)
            //                     .Where(i => i.user_id == id).ToList();
            // var userTransaction = _context.users.Include(u => u.transaction)
            //                         .Where(u => u.user_id == id).ToList();
                // return Json(action);

            return RedirectToAction("UserAccount", new { id = user_id});
            // return View("UserAccount");
        }


       
    }
}
