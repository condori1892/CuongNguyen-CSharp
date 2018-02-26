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
    [Route("dashboard")]
    public class DashboardController : Controller
    {
        public DashboardController()
        {

        }
        
        [HttpGet("")]
        public IActionResult Index()
        {
            
            if(HttpContext.Session.GetInt32("id") == null)
                return RedirectToAction("Index", "Home");

            ViewBag.userName = HttpContext.Session.GetString("name");
            ViewBag.userID = HttpContext.Session.GetInt32("id");
            string messages = @"SELECT u.first_name, u.last_name, m.users_id, m.id AS message_id, m.message, m.created_at 
            FROM users AS u 
            JOIN messages AS m ON u.id = m.users_id 
            ORDER BY m.created_at DESC";

            string comments = @"SELECT u.first_name, u.last_name, c.id, c.users_id, c.comment, c.created_at, m.id AS messages_id
            FROM users AS u
            JOIN comments AS c ON u.id = c.users_id
            JOIN messages AS m ON m.id = c.messages_id
            ORDER BY c.created_at DESC";

            
            DashboardModel dashboardModel = new DashboardModel()
            {
                //  allMessages = DbConnector.Query("SELECT users.first_name, users.last_name, messages.id, messages.message, messages.created_at FROM users INNER JOIN messages ON users.id = messages.users_id ORDER BY messages.created_at DESC")
                allComments = DbConnector.Query(comments),
                allMessages = DbConnector.Query(messages)

                
            };

            
            // return View("Success", dashboardModel);
            return View("Index", dashboardModel);
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
            DashboardModel dashboardModel = new DashboardModel()
            {
                 allMessages = DbConnector.Query("SELECT users.first_name, users.last_name, messages.id, messages.message, messages.created_at FROM users INNER JOIN messages ON users.id = messages.users_id ORDER BY messages.created_at DESC"),
                newMessage = model
            };
            // if(!ModelState.IsValid)
            //     return View("Dashboard", dashboardModel);

            // return View("Index");
            return RedirectToAction("Index");
        }
        [HttpPost("createComment")]
        public IActionResult CreateComment(Comment model)
        {
            // Message incomingMessage = model.newMessage;
            if(ModelState.IsValid)
            {
            int? u_id = HttpContext.Session.GetInt32("id");
            
            string query = $@"INSERT INTO comments (users_id, messages_id, comment, created_at, 
            updated_at) VALUES ('{u_id}', '{model.messages_id}', '{model.comment}', NOW(), NOW())";
            DbConnector.Execute(query);
            }
            DashboardModel dashboardModel = new DashboardModel()
            {
                 allMessages = DbConnector.Query("SELECT users.first_name, users.last_name, messages.id, messages.message, messages.created_at FROM users INNER JOIN messages ON users.id = messages.users_id ORDER BY messages.created_at DESC"),
                newComment = model
            };
            // if(!ModelState.IsValid)
            //     return View("Dashboard", dashboardModel);

            
            return RedirectToAction("Index");
        }

        [HttpPost("deleteMessage")]
        public IActionResult DeleteMessage(Message model)
        {
            int? mID = model.id;
            int? uID = model.users_id;
            string c_delete = $"DELETE FROM comments WHERE messages_id = '{mID}'";
            string m_delete = $"DELETE FROM messages WHERE id = '{mID}'";

            
            string checkMessageHaveComments = $"SELECT * FROM comments WHERE messages_id = '{mID}'";
            if(DbConnector.Query(checkMessageHaveComments) != null)
                DbConnector.Execute(c_delete);
                
            DbConnector.Execute(m_delete);
            
            return RedirectToAction("Index");
        }

        [HttpPost("deleteComment")]
        public IActionResult DeleteComment(Comment model)
        {
            int? cID = model.id; 
            string c_delete = $"DELETE FROM comments WHERE id = '{cID}'";
            DbConnector.Execute(c_delete);
            
            return RedirectToAction("Index");
        }


    }
}
