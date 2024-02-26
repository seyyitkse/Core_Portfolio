using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.ViewComponents.Contact
{
    public class ContactPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
