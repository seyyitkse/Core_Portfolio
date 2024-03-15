using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Controllers
{
    public class WriterUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
