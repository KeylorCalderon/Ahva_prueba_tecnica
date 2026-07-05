using Microsoft.AspNetCore.Mvc;

namespace AhvaPrueba.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}