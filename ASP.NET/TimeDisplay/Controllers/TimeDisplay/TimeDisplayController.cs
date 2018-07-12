using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TimeDisplay.Controllers
{
    public class TimeDisplayController : Controller
    {
        [HttpGet]
        [Route("index")]
        public string Index()
        {
            return "Hello World!";
        }
        [HttpGet]
        [Route("home")]
        public IActionResult time()
        {
            return View();
        }
    }
}