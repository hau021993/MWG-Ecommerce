using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using MWG_Ecommerce.Data;
using MWG_Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MWG_Ecommerce.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly ShoppingonlineContext _context;

        public AuthController(ILogger<AuthController> logger, ShoppingonlineContext context)
        {
            _logger = logger;
            _context = context;
        }

        public ActionResult Login()
        {
            return View("Views/Login/LoginPage.cshtml");
        }

        // POST: login with username vs password
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string pass)
        {

            var user = _context.Users.Where(u => u.Username == username && u.Passwword == pass).FirstOrDefault();
            if (user != null)
            {
                bool checkAdmin = user.Role;
                HttpContext.Session.SetString("username", user.Username);
                if (checkAdmin == false)
                {
                    HttpContext.Session.SetString("role", "ROLE_USER");
                }
                else
                {
                    HttpContext.Session.SetString("role", "ROLE_ADMIN");
                }
                return Redirect(Url.Action("Index", "Admin"));
            }
            else
            {
                TempData["ThongBao"] = "Tài khoản hoặc mật khẩu không hợp lệ";
                return RedirectToAction(nameof(Login));
            }

        }
        // Logout
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(nameof(Login));
        }
    }
}
