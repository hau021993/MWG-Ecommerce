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
using MWG_Ecommerce.Helpers;

namespace MWG_Ecommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly ShoppingonlineContext _context;
        private readonly CategoryService categoryService;
        private readonly SupplierService supplierService;
        private readonly PaymentService paymentService;

        public CartController(ILogger<CartController> logger, ShoppingonlineContext context)
        {
            _logger = logger;
            _context = context;
            categoryService = new CategoryService(context);
            supplierService = new SupplierService(context);
            paymentService = new PaymentService(context);
        }

        public List<CartItem> Carts
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (data == null)
                {
                    data = new List<CartItem>();
                }
                return data;
            }
        }

        
        public IActionResult Index()
        {
            ViewData["CategoryList"] = categoryService.GetAllCategories();
            ViewData["SupplierList"] = supplierService.GetAllSupplier();
            return View(Carts);
        }

        public IActionResult AddToCart(int id, int Quanlity, string type = "Normal")
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.ProductId == id);

            if (item == null) //Chưa có
            {
                var product = _context.Products.SingleOrDefault(p => p.ProductId == id);
                item = new CartItem
                {
                    ProductId = id,
                    ProductName = product.ProductName,
                    Price = (double)product.Price,
                    Quanlity = Quanlity,
                    Picture = product.Picture
                };
                myCart.Add(item);
            }
            else
            {
                item.Quanlity += Quanlity;
            }
            HttpContext.Session.Set("GioHang", myCart);

            if (type == "ajax")
            {
                return Json(new
                {
                    Quanlity = Carts.Sum(c => c.Quanlity)
                });
            }

            return RedirectToAction("Index");
        }

        public IActionResult UpdateCart(int id, int Quanlity)
        {
            var myCart = Carts;
            var item = myCart.Find(p => p.ProductId == id);

            if (item != null) 
            {
                item.Quanlity = Quanlity;
            }          
            HttpContext.Session.Set("GioHang", myCart);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveCart(int id)
        {
            var myCart = Carts;
            var item = myCart.Find(p => p.ProductId == id);

            if (item == null) //Chưa có
            {
                return NotFound();
            }
            else
            {
                myCart.Remove(item);
                
            }
            HttpContext.Session.Set("GioHang", myCart);           
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            ViewData["CategoryList"] = categoryService.GetAllCategories();
            ViewData["SupplierList"] = supplierService.GetAllSupplier();
            ViewData["PaymentList"] = paymentService.GetAllPayment();
            return View();
        }

    }
}
