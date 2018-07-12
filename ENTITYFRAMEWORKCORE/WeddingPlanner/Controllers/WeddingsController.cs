using System;
using System.Linq;
using System.Diagnostics;
using WeddingPlanner.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// Other usings

namespace WeddingPlanner.Controllers
{
    public class WeddingsController : Controller
    {
        private WeddingPContext _context;

        public WeddingsController(WeddingPContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            int? CurrentUserId = HttpContext.Session.GetInt32("CurrentUser");             
            // if (AccountId != CurrentUserId)
            // {
            //     HttpContext.Session.Clear();
            //     return RedirectToAction("Login", "Users");
            // }
            if(CurrentUserId != null)
            {
                Users DashboardUser = _context.Users.SingleOrDefault(u => u.UserId == (int)CurrentUserId);
                List<Wedders> AllWeddings = _context.Wedders
                            .OrderByDescending(w => w.Date)
                            // .Include( w => w.User)                        
                            .Include( w => w.Visitors) 
                                .ThenInclude(visitors => visitors.Users)
                            .ToList();         
                // List<Users> AllUsers = _context.Users.ToList();
                // List of all Users
                List<Users> AllUsers = _context.Users
                            .Include(v => v.Visitors)
                                .ThenInclude(w => w.Wedders)
                            .ToList();
                ViewBag.CurrentUser = DashboardUser;
                ViewBag.CurrentUserId = CurrentUserId;
                ViewBag.Weddings = AllWeddings;
                ViewBag.AllUsers = AllUsers;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Users");                
            }

            // Other code
        }
        [HttpGet]
        [Route("create")]
        public IActionResult PlanWedding()
        {
            int? CurrentUserId = HttpContext.Session.GetInt32("CurrentUser");            
            if(CurrentUserId == null)
            {
                return RedirectToAction("Login", "Users");
            }
            return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult PlanWedding(Wedders NewWedding)
        {
            int? CurrentUserId = HttpContext.Session.GetInt32("CurrentUser");
            Users Creator = _context.Users.SingleOrDefault(u => u.UserId == CurrentUserId);  
                          
          if (ModelState.IsValid)
          {
            NewWedding.UserId = (int)CurrentUserId;
            _context.Wedders.Add(NewWedding);
            _context.SaveChanges();

            // Visitors NewVisitor = new Visitors(){
            //     UserId = (int)CurrentUserId,
            //     WeddersId = NewWedding.UserId
            // };
            // _context.Visitors.Add(NewVisitor);
            // _context.SaveChanges();
            
            return RedirectToAction("Dashboard");
          }
            return View();
        }
        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(int WeddersId)
        {
            Wedders NewWedding = _context.Wedders.SingleOrDefault(w => w.WeddersId == WeddersId);
            _context.Remove(NewWedding);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpPost]
        [Route("rsvp")]
        public IActionResult RSVP(int WeddersId)
        {
            int? CurrentUserId = HttpContext.Session.GetInt32("CurrentUser");             
            Users DashboardUser = _context.Users.SingleOrDefault(u => u.UserId == (int)CurrentUserId);  
           
            // Wedders NewWedding = _context.Wedders.SingleOrDefault(w => w.WeddersId == WeddersId);
                      
                Visitors NewVisitor = new Visitors(){
                    UserId = (int)CurrentUserId,
                    WeddersId = WeddersId
                };
                _context.Add(NewVisitor);
                _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpPost]
        [Route("unrsvp")]
        public IActionResult UNRSVP(int WeddersId)
        {
            int? CurrentUserId = HttpContext.Session.GetInt32("CurrentUser");             
            Users DashboardUser = _context.Users.SingleOrDefault(u => u.UserId == (int)CurrentUserId);    

            Wedders NewWedding = _context.Wedders.SingleOrDefault(w => w.WeddersId == WeddersId);                  
            Visitors RemoveVisitor = _context.Visitors.SingleOrDefault(v => v.WeddersId == NewWedding.WeddersId && v.UserId == DashboardUser.UserId);
            _context.Remove(RemoveVisitor);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpGet]
        [Route("show/{WeddersId}")]
        public IActionResult Show(int WeddersId)
        {
            Wedders AllWeddings = _context.Wedders.Where(w => w.WeddersId == WeddersId)                      
                        .Include( w => w.Visitors) 
                            .ThenInclude(visitors => visitors.Users)
                        .SingleOrDefault();
                    
            // Wedders NewWedding = AllWeddings.SingleOrDefault(w => w.WeddersId == WeddersId);                             
            ViewBag.Weddings = AllWeddings;                              
          return View();
        }
    }
}