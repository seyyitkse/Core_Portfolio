using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Core_Portfolio.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EfWriterMessageDal());
        private readonly UserManager<WriterUser> userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task< IActionResult> RecevierMessage(string p)
        {
            var values = await userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = writerMessageManager.GetListRecevierMessages(p);
            return View(messageList);
        }
        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = writerMessageManager.GetListSenderMessages(p);
            return View(messageList);
        }
        public IActionResult MessageDetails(int id)
        {
            WriterMessage values = writerMessageManager.TGetByID(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(WriterMessage message)
        {
            var values = await userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name=values.Name+" "+values.Surname;
            Context c = new Context();
            var receivername = c.Users.Where(x => x.Email == message.Recevier).Select(y=>y.Name+" "+y.Surname).FirstOrDefault();     
            message.Date=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.Sender = mail;
            message.SenderName =name;
            message.RecevierName = receivername;
            writerMessageManager.TAdd(message);
            return RedirectToAction("SenderMessage","Message");
        }

    }
}
