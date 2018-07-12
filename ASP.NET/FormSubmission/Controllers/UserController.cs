using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            return View();
        }

        //Other code
        [HttpPost]
        [Route("register")]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
                //Handle success
            }
            // return RedirectToAction("Index");
            return View("Index");
        }
    }
}
