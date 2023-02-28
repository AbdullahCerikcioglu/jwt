using Microsoft.AspNetCore.Mvc;

namespace Udemy.JwtApp.Api.Controllers
{
    public class denemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
