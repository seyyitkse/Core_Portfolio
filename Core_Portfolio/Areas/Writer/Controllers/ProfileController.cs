using BusinessLayer.Concrete;
using Core_Portfolio.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.ImageURL=values.ImageURL;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEdit)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (userEdit.Image!=null) 
            {
                var resource = Directory.GetCurrentDirectory();
                var extension= Path.GetExtension(userEdit.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimage/" + imagename;
                var stream=new FileStream(savelocation, FileMode.Create);
                await userEdit.Image.CopyToAsync(stream);
                user.ImageURL = imagename;
            }
            user.Name=userEdit.Name;
            user.Surname=userEdit.Surname;
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded) 
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
