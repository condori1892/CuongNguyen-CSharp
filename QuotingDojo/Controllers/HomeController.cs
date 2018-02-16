using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using System.ComponentModel.DataAnnotations;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("quotes")]
        public IActionResult Quote()
        {
            string query = "SELECT * FROM quotes ORDER BY created_at DESC";
            ViewBag.quotes = DbConnector.Query(query);
            return View();
        }

        [HttpPost("quotes")]
        public IActionResult Create(Quote Q)
        {
            if(ModelState.IsValid)
            {
                string query = $@"INSERT INTO quotes (name, quoting, created_at, updated_at) 
                VALUES ('{Q.name}', '{Q.quote}', NOW(), NOW())";
                DbConnector.Execute(query);
                // ViewBag.success = "Successful! Adding Quote";
                return RedirectToAction("Index");
            }  
            return View("Index");
           
        }

    }
}
