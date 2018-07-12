using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers
{
    public class DojoSurveyController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Index()
        {
            return "Hello World!";
        }
        [HttpGet]
        [Route("survey")]
        public IActionResult survey()
        {
            return View();
        }
        [HttpPost]
        [Route("result")]
        public IActionResult result(string name, string location, string language, string comment)
        {
            ViewBag.Name = name;
            ViewBag.DojoLocation = location;
            ViewBag.FavoriteLanguage = language;
            ViewBag.comment = comment;
            return View();
        }
    }
}