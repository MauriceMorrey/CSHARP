using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokeInfo.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace PokeInfo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            ViewData["Name"] = "My name is Maurice";

            return View();
        }
        public IActionResult PokeInfo()
        {
            ViewData["Message"] = "This page displays the above information.";
            ViewData["Name"] = "My name is Maurice";
            ViewData["Primary Type"] = "I'm of type A";
            ViewData["Height"] = "My height is short";
            ViewData["Weight"] = "My weight is medium heavy.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        [Route("pokemon/{pokeid}")]
        public IActionResult QueryPoke(int pokeid)
        {
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
                {
                    // PokeInfo = ApiResponse;
                    ViewBag.PokeInfo = ApiResponse;
                    
                }
            ).Wait();
            // ViewData["PokeInfo"] = ApiResponse;

            return View();
            // Other code
        }

    }
}
