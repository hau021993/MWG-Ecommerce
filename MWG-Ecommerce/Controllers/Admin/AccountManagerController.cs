﻿using Microsoft.AspNetCore.Mvc;

namespace MWG_Ecommerce.Controllers.Admin
{
    public class AccountManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
