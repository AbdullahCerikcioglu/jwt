using Microsoft.AspNetCore.Mvc;

namespace Udemy.JwtApp.Api.Controllers
{
    public class Homedenemee : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
