using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class PortfolioController : Controller
    {
        [HttpGet]
        [Route("index")]
        public string Index()
        {
            return "Hello World!";
        }
        [HttpGet]
        [Route("home")]
        public IActionResult home()
        {
            return View();
        }
        [HttpGet]
        [Route("projects")]
        public IActionResult projects()
        {
            return View();
        }
        [HttpGet]
        [Route("contacts")]
        public IActionResult contact()
        {
            return View();
        }
        [HttpPost]
        [Route("contacts")]
        public IActionResult contact(string name, string email, string message)
        {
            return View();
            // Return a view (We'll learn how soon!)
        }
    }
}
