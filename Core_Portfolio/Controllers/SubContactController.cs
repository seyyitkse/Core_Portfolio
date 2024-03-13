using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Controllers
{
    public class SubContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        public IActionResult Index()
        {
            var values = contactManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult UpdateSubContact(int id)
        {
            var values = contactManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateSubContact(Contact contact)
        {
                contactManager.TUpdate(contact);
                return RedirectToAction("Index");
        }
    }
}
