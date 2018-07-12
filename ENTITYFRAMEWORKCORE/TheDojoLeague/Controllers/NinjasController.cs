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
    public class NinjasController : Controller
    {
        private DojoLeagueContext _context;

        public NinjasController(DojoLeagueContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ninja")]
        public IActionResult Ninjas()
        {
            // List<Ninjas> AllNinjas = _context.Ninjas.ToList();
            ViewBag.Ninjas = _context.Ninjas.Include(n => n.Dojos).ToList();
            ViewBag.Dojos = _context.Dojos.Include(d => d.Ninjas).ToList();
            return View();
            // Other code
        }
        [HttpPost]
        [Route("registerninja")]
        public IActionResult RegisterNinja(Ninjas NewNinja)
        {
            if (ModelState.IsValid)
            {
                //  Ninjas NewNinja = new Ninjas()
                // {
                //     NinjaName = model.NinjaName,
                //     NinjaingLevel = model.NinjaingLevel,
                //     DojoId = model.DojoId,
                //     OptionalDescription = model.OptionalDescription,
                // };
                // _context.Add(NewNinja);
                // _context.SaveChanges();
                // ViewBag.Ninjas = _context.Ninjas.Include(n => n.Dojos).ToList();
                // ViewBag.Dojos = _context.Dojos.Include(d => d.Ninjas).ToList();
                Ninjas RegisteredNinja = _context.Ninjas.SingleOrDefault(i => i.NinjaId == NewNinja.NinjaId);
                if(RegisteredNinja != null)
                {
                    // ViewBag.Message = "This email exists. Please use a different email.";
                    ModelState.AddModelError("NinjaId","This ninja exists. Please choose a different name.");

                    return View("Ninjas");
                }
                NewNinja.DojoId = NewNinja.DojoId;
                _context.Ninjas.Add(NewNinja);
                _context.SaveChanges();
                // NewNinja = _context.Ninjas.SingleOrDefault(n => n.NinjaId == NewNinja.NinjaId);
                // HttpContext.Session.SetInt32("CurrentNinja", NewNinja.NinjaId);
                // int? CurrentNinjaId = HttpContext.Session.GetInt32("CurrentNinja");
                // ViewBag.CurrentNinja = NewNinja;
                ViewBag.Ninjas = _context.Ninjas.Include(n => n.Dojos).ToList();
                ViewBag.Dojos = _context.Dojos.Include(d => d.Ninjas).ToList();
                // return RedirectToAction("Account", "Transactions", new{AccountId});
                return RedirectToAction("Ninjas", "Ninjas");
                //Handle success
            }
            ViewBag.Ninjas = _context.Ninjas.Include(n => n.Dojos).ToList();
            ViewBag.Dojos = _context.Dojos.Include(d => d.Ninjas).ToList();
             return View("Ninjas");
        }
        [HttpGet]
        [Route("Ninjas/{NewNinjaId}")]
        public IActionResult NinjaPage(int NewNinjaId)
        {
            Ninjas NewNinja = _context.Ninjas.Where(n => n.NinjaId == NewNinjaId).Include(n => n.Dojos).SingleOrDefault();
            ViewBag.Ninjas = NewNinja;
            return View("Show");
            
        }

    }
}