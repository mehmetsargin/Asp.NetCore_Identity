﻿using Microsoft.AspNetCore.Mvc;

namespace MercurTech.PresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutScriptPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
