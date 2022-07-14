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
        private readonly ProductService productService;
        private readonly CategoryService categoryService;
        private readonly SupplierService supplierService;

        public HomeController(ILogger<HomeController> logger, ShoppingonlineContext context)
        {
            _logger = logger;
            _context = context;
            homeService = new HomeService(context);
            productService = new ProductService(context);
            categoryService = new CategoryService(context);
            supplierService = new SupplierService(context);
        }

        public IActionResult Index()
        {
            ViewData["CategoryList"] = categoryService.GetAllCategories();
            ViewData["SupplierList"] = supplierService.GetAllSupplier();
            ViewData["CountProduct_1"] = productService.CountProductOfCategory_1();
            ViewData["CountProduct_2"] = productService.CountProductOfCategory_2();
            ViewData["CountProduct_3"] = productService.CountProductOfCategory_3();
            ViewData["CountProduct_4"] = productService.CountProductOfCategory_4();
            ViewData["CountProduct_5"] = productService.CountProductOfCategory_5();
            ViewData["CountProduct_6"] = productService.CountProductOfCategory_6();
                 
            //HttpContext.Session.SetInt32("id", 2);
            return View(productService.GetTop10ProductView());
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
