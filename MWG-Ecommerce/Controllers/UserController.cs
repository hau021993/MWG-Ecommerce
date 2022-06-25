using Microsoft.AspNetCore.Mvc;
using MWG_Ecommerce.Models;
using MWG_Ecommerce.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace MWG_Ecommerce.Controllers
{
    public class UserController : Controller
    {
        private readonly shoppingonlineContext _context;

        public UserController(shoppingonlineContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<User> users = _context.Users.ToList();
            return View(users);
        }
    }
}
