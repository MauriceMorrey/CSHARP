using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LostInTheWoods.Factory;
using LostInTheWoods.Models;

namespace LostInTheWoods.Controllers
{
    public class LostInTheWoodsController : Controller
    {
        private readonly TrailFactory trailFactory;
        public LostInTheWoodsController()
        {
            trailFactory = new TrailFactory();
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Trails = trailFactory.FindAll();
            System.Console.WriteLine(ViewBag.Trails[0].id);           
            System.Console.WriteLine($"Length is {ViewBag.Trails.Count}");
            return View();
        }
        [HttpGet]
        [Route("new")]
        public IActionResult NewTrail()
        {
            return View();
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Add(Trail NewTrail)
        {
            if (ModelState.IsValid)
            {
                trailFactory.Add(NewTrail);
                System.Console.WriteLine("write stuff");
                return RedirectToAction("Index");
            }
            return View("NewTrail");
        }
        [HttpGet]
        [Route("trails/{id}")]
        public IActionResult ShowTrail(string id)
        {
            ViewBag.Trails = trailFactory.FindByID(Int32.Parse(id));
            return View();
        }
    }
}