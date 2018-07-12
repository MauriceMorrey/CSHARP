using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {

        // Other code
        [HttpGet]
        [Route("")]
        public IActionResult Quote()
        {
            ViewBag.Info = DbConnector.Query("SELECT * FROM quotes");

            // Other code
            return View();
        }

    }
}
