using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            WriterMessage values = writerMessageManager.TGetByID(id);
            return View(values);
        }
    }
}
