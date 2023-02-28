using Microsoft.AspNetCore.Mvc;

namespace Udemy.JwtApp.Api.Controllers
{
    public class SonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
