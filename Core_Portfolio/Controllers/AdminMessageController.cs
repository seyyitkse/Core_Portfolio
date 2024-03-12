using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager messageManager = new WriterMessageManager(new EfWriterMessageDal());
        public IActionResult ReceiverMessageList()
        {
            string mail = "admin@mail.com";
            var values=messageManager.GetListRecevierMessages(mail);
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            string mail = "admin@mail.com";
            var values = messageManager.GetListSenderMessages(mail);
            return View(values);
        }
        public IActionResult DeleteAdminMessage(int id)
        {
            var values = messageManager.TGetByID(id);
            messageManager.TDelete(values);
            return RedirectToAction("SenderMessageList");
        }
        public IActionResult AdminMessageDetails(int id)
        {
            var values=messageManager.TGetByID(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage newMessage)
        {
            newMessage.Sender = "admin@mail.com";
            newMessage.SenderName = "Admin";
            Context c=new Context();
            var receivername= c.Users.Where(x => x.Email == newMessage.Recevier).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            newMessage.RecevierName = "Test";
            messageManager.TAdd(newMessage);
            return RedirectToAction("SenderMessageList");
        }
    }
}
