using Microsoft.AspNetCore.Mvc;

namespace Udemy.JwtApp.Api.Controllers
{
    public class Deneme2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
