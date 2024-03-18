using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userDetails = await userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserDetails = userDetails.Name+" "+userDetails.Surname;
            ViewBag.ImageURL = userDetails.ImageURL;
            return View();
        }
    }
}
