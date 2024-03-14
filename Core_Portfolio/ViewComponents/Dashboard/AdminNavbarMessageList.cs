using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList:ViewComponent
    {
        WriterMessageManager messageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IViewComponentResult Invoke()
        {
            string mail = "admin@mail.com";
            var values = messageManager.GetListRecevierMessages(mail).OrderByDescending(x => x.WriterMessageID).Where(x=>x.Recevier==mail).Take(3).ToList();
            return View(values);
        }
    }
}
