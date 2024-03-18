using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        WriterMessageManager messageManager = new WriterMessageManager(new EfWriterMessageDal());
        private readonly UserManager<WriterUser> userManager;

        public AdminMessageController(UserManager<WriterUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> ReceiverMessageList()
        {
            var userDetails = await userManager.FindByNameAsync(User.Identity.Name);
            var values = messageManager.GetListRecevierMessages(userDetails.Email);
            return View(values);
        }
        public async Task<IActionResult> SenderMessageList()
        {
            var userDetails = await userManager.FindByNameAsync(User.Identity.Name);
            var values = messageManager.GetListSenderMessages(userDetails.Email);
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
        public async Task<IActionResult> AdminMessageSend(WriterMessage newMessage)
        {
            var userDetails = await userManager.FindByNameAsync(User.Identity.Name);
            newMessage.Sender = userDetails.Email;
            newMessage.SenderName = userDetails.Name;
            newMessage.Date=DateTime.Now;
            Context c=new Context();
            var receivername= c.Users.Where(x => x.Email == newMessage.Recevier).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            newMessage.RecevierName = "Test";
            messageManager.TAdd(newMessage);
            return RedirectToAction("SenderMessageList");
        }
    }
}
