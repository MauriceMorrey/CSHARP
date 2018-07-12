using System;
using System.Linq;
using System.Diagnostics;
using TheDojoLeague.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// Other usings

namespace TheDojoLeague.Controllers
{
    public class DojosController : Controller
    {
        private DojoLeagueContext _context;

        public DojosController(DojoLeagueContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("dojo")]
        public IActionResult Dojos()
        {
            // List<Dojos> AllDojos = _context.Dojos.ToList();
            ViewBag.Dojos = _context.Dojos.Include(d => d.Ninjas).ToList();
            ViewBag.Ninjas = _context.Ninjas.Include(n => n.Dojos).ToList();
            return View();
            // Other code
        }
        [HttpPost]
        [Route("registerdojo")]
        public IActionResult RegisterDojo(Dojos NewDojo)
        {
            if (ModelState.IsValid)
            {
                Dojos RegisteredDojo = _context.Dojos.SingleOrDefault(i => i.DojoId == NewDojo.DojoId);
                if (RegisteredDojo != null)
                {
                    // ViewBag.Message = "This email exists. Please use a different email.";
                    ModelState.AddModelError("DojoName", "This ninja exists. Please choose a different name.");

                    return View("Dojos");
                }
                _context.Dojos.Add(NewDojo);
                _context.SaveChanges();
                NewDojo = _context.Dojos.SingleOrDefault(i => i.DojoId == NewDojo.DojoId);
                ViewBag.Dojos = _context.Dojos.Include(d => d.Ninjas).ToList();
                ViewBag.Ninjas = _context.Ninjas.Include(n => n.Dojos).ToList();
                HttpContext.Session.SetInt32("CurrentDojo", NewDojo.DojoId);
                int? CurrentDojoId = HttpContext.Session.GetInt32("CurrentDojo");
                ViewBag.CurrentDojo = NewDojo;
                // return RedirectToAction("Account", "Transactions", new{AccountId});
                return RedirectToAction("Dojos", "Dojos");
                //Handle success
            }
            ViewBag.Dojos = _context.Dojos.Include(d => d.Ninjas).ToList();
            ViewBag.Ninjas = _context.Ninjas.Include(n => n.Dojos).ToList();
            return View("Dojos");
        }
        [HttpGet]
        [Route("Dojos/{NewDojoId}")]
        public IActionResult DojoPage(int NewDojoId)
        {
            Dojos NewDojo = _context.Dojos.Where(n => n.DojoId == NewDojoId).Include(n => n.Ninjas).SingleOrDefault();
            ViewBag.Dojos = NewDojo;
            ViewBag.DojoMembers = _context.Ninjas.Include(n => n.Dojos).Where(n => n.Dojos.DojoId == NewDojoId).ToList();
            ViewBag.RogueNinjas = _context.Ninjas.Include(n => n.Dojos).Where(n => n.Dojos.DojoId == 0).ToList();
            return View("Show");
        }
        [HttpGet]
        [Route("Recruit/{NewDojoId}/{NewNinjaId}")]
        public IActionResult Recruit(int NewDojoId, int NewNinjaId)
        {
            Ninjas NewNinja = _context.Ninjas.SingleOrDefault(n => n.NinjaId == NewNinjaId);
            Dojos NewDojo = _context.Dojos.SingleOrDefault(d => d.DojoId == NewDojoId);
            NewNinja.Dojos.DojoName = NewDojo.DojoName;
            _context.SaveChanges();
            return RedirectToAction("Show", new { DojoId = NewDojoId });
        }

        [HttpGet]
        [Route("Banish/{NewDojoId}/{NewNinjaId}")]
        public IActionResult Banish(int NewDojoId, int NewNinjaId)
        {
            Ninjas NewNinja = _context.Ninjas.SingleOrDefault(n => n.DojoId == NewNinjaId);
            NewNinja.Dojos.DojoName = null;
            _context.SaveChanges();
            ViewBag.Banish = NewNinja;
            return RedirectToAction("Show", new { DojoId = NewDojoId });
        }
    }
}
