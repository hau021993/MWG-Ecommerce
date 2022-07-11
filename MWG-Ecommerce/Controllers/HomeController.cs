using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MWG_Ecommerce.Data;
using MWG_Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MWG_Ecommerce.Service;

namespace MWG_Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShoppingonlineContext _context;
        private readonly HomeService homeService;

        public HomeController(ILogger<HomeController> logger, ShoppingonlineContext context)
        {
            _logger = logger;
            _context = context;
            homeService = new HomeService(context);
        }

        public IActionResult Index()
        {
            ViewData["CategoryList"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierList"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            //HttpContext.Session.SetInt32("id", 2);
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.SessionUserId = HttpContext.Session.GetInt32("id");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
