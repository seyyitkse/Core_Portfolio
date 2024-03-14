using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Controllers
{        
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        ContactMessageManager messageManager =new ContactMessageManager(new EfContactMessageDal());
        public IActionResult Index()
        {
            var values = messageManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteContactMessage(int id)
        {
            var values=messageManager.TGetByID(id);
            messageManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ContactMessageDetails(int id)
        {
            var values = messageManager.TGetByID(id);
            return View(values);
        }
    }
}
