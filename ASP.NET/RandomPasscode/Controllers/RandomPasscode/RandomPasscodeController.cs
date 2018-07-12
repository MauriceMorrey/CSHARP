using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace RandomPasscode.Controllers
{
    public class RandomPasscodeController : Controller
    {
        [HttpGet]
        [Route("index")]
        public string Index()
        {
            return "Hello World!";
        }
        [HttpGet]
        [Route("random")]
        public IActionResult passcode()
        {
            int? count = HttpContext.Session.GetInt32("count");
            if (count == null)
            {
                count = 0;
            }
            count += 1;
            Random rand = new Random();
            string RandomChar = "0123456789QWERTYUIOPASDFGHJKLZXCVBNM";
            string RandomPass = "";
            for (int i = 0; i < 14; i++)
            {
                RandomPass += RandomChar[rand.Next(0, RandomChar.Length)];
            }
            ViewBag.Count = count;
            ViewBag.RandomPass = RandomPass;
            HttpContext.Session.SetInt32("count", (int)count);

            return View();
        }
        [HttpGet]
        [Route("reset")]
        public IActionResult Reset()
        {
            // int? count = HttpContext.Session.GetInt32("count");
            // if (count != null)            
            // {
            // count = 0;            
            // }
            HttpContext.Session.Clear();
            // Will redirect to the <method name> method
            return RedirectToAction("passcode");
        }

    }
}