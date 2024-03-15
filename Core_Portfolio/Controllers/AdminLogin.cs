using Core_Portfolio.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Controllers
{
    [AllowAnonymous]
    public class AdminLogin : Controller
    {
        private readonly SignInManager<WriterUser> _signInManager;
        private readonly UserManager<WriterUser> _userManager;

        public AdminLogin(SignInManager<WriterUser> signInManager, UserManager<WriterUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AdminLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Username);
                    var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

                    if (isAdmin)
                    {
                        // Admin rolüne sahipse, Dashboard'a yönlendir
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        // Admin rolüne sahip değilse, çıkış yap ve hata mesajı göster
                        await _signInManager.SignOutAsync();
                        ModelState.AddModelError("", "Only administrators can log in here.");
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "AdminLogin");
        }
    }
}
