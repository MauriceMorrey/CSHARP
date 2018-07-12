using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallingCard.Controllers
{
    public class CallingCardController : Controller
    {
        //A GET method
        [HttpGet]
        [Route("index")]
        public string Index()
        {
            return "Hello World!";
        }
        // //A POST method
        // [HttpPost]
        // [Route("")]
        // public IActionResult Other()
        // [HttpGet]
        // [Route("displayint")]
        // public JsonResult DisplayInt()
        // {
        //     return Json(34);
        // }
        [HttpGet]
        [Route("/{Raz}/{Aquato}/{10}/{Blue}")]
        public JsonResult CallingCard(string FirstName, string LastName, int Age, string FavoriteColor)
        {
            var AnonObject = new
            {
                FirstName = "Raz",
                LastName = "Aquato",
                Age = 10,
                FavoriteColor = "Blue",
            };
            return Json(AnonObject);
        }
    }
}
