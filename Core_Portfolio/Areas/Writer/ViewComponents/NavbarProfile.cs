using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Areas.Writer.ViewComponents
{
    public class NavbarProfile:ViewComponent
    {
        private readonly UserManager<WriterUser> userManager;

        public NavbarProfile(UserManager<WriterUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var values = await userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.URL=values.ImageURL;
            return View();
        }
    }
}
