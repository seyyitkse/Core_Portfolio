using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace Core_Portfolio.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task< IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Name = values.Name + " " + values.Surname;

            //weather api
            string api = "bcd9fc51f2895f4c938ab6b8cc7c115f";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=ankara&mode=xml&lang=en&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.WeatherCelsius = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.WeatherCity = document.Descendants("city").ElementAt(0).Attribute("name").Value;
            ViewBag.WeatherPressure = document.Descendants("pressure").ElementAt(0).Attribute("value").Value;

            //statistics
            Context context = new Context();
            ViewBag.Sender = context.WriterMessages.Where(x=>x.Sender==values.Email).Count();
            ViewBag.Announcement=context.Announcements.Count();
            ViewBag.User=context.Users.Count();
            ViewBag.Skill=context.Skills.Distinct().Count();
            return View(values );
        }
    }
}
