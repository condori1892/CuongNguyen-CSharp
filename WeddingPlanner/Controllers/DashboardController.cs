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
    [Route("dashboard")]
    public class DashBoardController : Controller
    {
        private WeddingContext _context;
    
        public DashBoardController(WeddingContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("user_id") == null)
                return RedirectToAction("Index", "Home");
            
            
            var model = _context.weddings.Include(s => s.rsvpGuests)
                                            .ThenInclude(a => a.rsvpGuest).ToList();

            Wedding deleteWedding = _context.weddings.Include(d => d.rsvpGuests)
                                                    .ThenInclude(e => e.rsvpGuest)
                                                    .SingleOrDefault(c => c.wed_date <= DateTime.Today);
            if(deleteWedding != null)
            {
                _context.weddings.Remove(deleteWedding);
                _context.SaveChanges();
                
            }
            
            ViewBag.id = HttpContext.Session.GetInt32("user_id");        
                                    
            return View(model);
        }

        [HttpGet("newwedding")]
        public IActionResult NewWedding()
        {
            if(HttpContext.Session.GetInt32("user_id") == null)
                return RedirectToAction("Index", "Home");
            return View("NewWedding");
        }

        [HttpPost("newwedding")]
        public IActionResult NewWedding(Wedding aWedding)
        {
            //Have to book 6 months in advance
            if(aWedding.wed_date <= DateTime.Now.AddMonths(6))
                ModelState.AddModelError("wed_date", "Wedding date must be 6 month in advance!");
            if(ModelState.IsValid)
            {
                int user_id = (int)HttpContext.Session.GetInt32("user_id");
                var checkCreator = _context.weddings.SingleOrDefault(w => w.creator == user_id);
                if(checkCreator == null)
                {
                    aWedding.creator = user_id;
                    _context.weddings.Add(aWedding);
                    _context.SaveChanges();
                    int id = aWedding.wedding_id;
                    
                }
                else
                {
                    ModelState.AddModelError("wedder_one", "You already created one!!");
                }
            }
            if(ModelState.IsValid)
                return RedirectToAction("Index", "DashBoard");
            return View(aWedding);

        }

        [HttpGet("{id}")]
        public IActionResult ShowWedding(int id)
        {
            var model = _context.weddings.Include(u => u.rsvpGuests).ThenInclude(a => a.rsvpGuest)
                                            .SingleOrDefault(w => w.wedding_id == id);


            return View("ShowWedding", model);
        }
        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if(HttpContext.Session.GetInt32("user_id") == null)
                return RedirectToAction("Index", "Home");

            int user_id = (int)HttpContext.Session.GetInt32("user_id");
            // Wedding deleteWedding = _context.weddings.SingleOrDefault(w => w.wedding_id == id);
            //test1
            Wedding deleteWedding = _context.weddings.Include(d => d.rsvpGuests)
                                                    .ThenInclude(e => e.rsvpGuest)
                                                    .SingleOrDefault(c => c.creator == user_id);
            if(deleteWedding != null)
            {
                
                if(deleteWedding.creator == user_id)
                {
                    _context.weddings.Remove(deleteWedding);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "DashBoard");
        }

        [HttpGet("rsvp/{id}")]
        public IActionResult RSVP(int id)
        {
            if(HttpContext.Session.GetInt32("user_id") == null)
                return RedirectToAction("Index", "Home");

            int user_id = (int)HttpContext.Session.GetInt32("user_id");
            RSVP checkRSVP = _context.rsvps.Where(r => r.user_id == user_id)
                                            .SingleOrDefault(w => w.wedding_id == id);
            if(checkRSVP != null)
            {
                // RSVP removeRSVP = _context.rsvps.SingleOrDefault(s => s.wedding_id == id);
                _context.rsvps.Remove(checkRSVP);
                _context.SaveChanges();
                // RSVP removeRSV
            }
            else
            {
                
                RSVP newRSVP = new RSVP()
                {
                    wedding_id = id,
                    user_id = user_id
                };
                _context.rsvps.Add(newRSVP);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "DashBoard");
        }
    



    }
    
}
