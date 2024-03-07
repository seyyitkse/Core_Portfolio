using Core_Portfolio.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(UserRegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı adı için benzersizlik kontrolü
                var existingUserName = await _userManager.FindByNameAsync(user.UserName);
                if (existingUserName != null)
                {
                    ModelState.AddModelError("", "Bu kullanıcı adı zaten mevcut.");
                    return View(user);
                }

                // E-posta adresi için benzersizlik kontrolü
                var existingEmail = await _userManager.FindByEmailAsync(user.Mail);
                if (existingEmail != null)
                {
                    ModelState.AddModelError("", "Bu e-posta adresi zaten mevcut.");
                    return View(user);
                }

                // Kullanıcıyı kaydetme işlemi
                var writerUser = new WriterUser()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    ImageURL = user.ImageURL,
                    Email = user.Mail,
                    UserName = user.UserName,
                };
                if (user.Password == user.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(writerUser, user.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }

            }
            return View(user);
        }

    }
}
