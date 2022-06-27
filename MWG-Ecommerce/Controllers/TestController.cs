using Microsoft.AspNetCore.Mvc;
using MWG_Ecommerce.Models;
using MWG_Ecommerce.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace MWG_Ecommerce.Controllers
{
    public class TestController : Controller
    {
        private readonly ShoppingonlineContext _context;

        public TestController(ShoppingonlineContext context)
        {
            _context = context;
        }
        public IActionResult ShowUser()
        {
            List<User> users = _context.Users.ToList();
            return View(users);
        }

        public IActionResult ShowProduct()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult ShowCategory()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }
    }
}
