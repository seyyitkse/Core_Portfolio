using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Portfolio.ViewComponents.Dashboard
{
    public class StatisticsDashboard2:ViewComponent
    {
        Context context=new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.ProjectCount = context.Portfolios.Count();
            ViewBag.TotalPrice= context.Portfolios.Sum(x => x.Price).ToString();
            ViewBag.LastSkills = context.Experiences.Where(x => x.Date == "2023").Count();
            return View();
        }
    }
}
