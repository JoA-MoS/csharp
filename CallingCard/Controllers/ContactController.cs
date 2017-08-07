using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallingCard.Controllers
{
    public class ContactController : Controller
    {

        [HttpGet]
        [Route("")]
        public JsonResult Index(string first,string last, int age, string color)
        {
            var result = new {
                         FirstName = first,
                         LastName = last,
                         Age = age,
                         FavoriteColor = color,
                     };
            return Json(result);
        }

    }
}
