using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
