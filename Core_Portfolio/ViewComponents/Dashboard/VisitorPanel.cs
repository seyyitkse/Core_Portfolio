﻿using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio.ViewComponents.Dashboard
{
    public class VisitorPanel:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
