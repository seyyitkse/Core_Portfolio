﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SendMessage(ContactMessage message)
        {
            //MessageManager messageManager = new MessageManager(new EfMessageDal());
            //message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //message.Status = true;
            //messageManager.TAdd(message);
            return PartialView();
        }
    }
}
