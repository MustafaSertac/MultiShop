﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultContoller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
