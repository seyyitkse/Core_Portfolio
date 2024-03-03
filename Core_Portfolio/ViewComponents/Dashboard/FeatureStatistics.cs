using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.ViewComponents.Dashboard
{
    public class FeatureStatistics:ViewComponent
    {
        Context context=new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.SkillQuantity=context.Skills.Count();
            ViewBag.Unread=context.Messages.Where(x=>x.Status==true).Count();
            ViewBag.Read=context.Messages.Where(x=>x.Status==false).Count();
            ViewBag.Experience = context.Experiences.Count();
            return View();
        }
    }
}
