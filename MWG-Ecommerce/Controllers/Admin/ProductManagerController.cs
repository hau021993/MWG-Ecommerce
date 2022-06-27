using MWG_Ecommerce.DTO;
using MWG_Ecommerce.Data;
using MWG_Ecommerce.Models;
using MWG_Ecommerce.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWG_Ecommerce.Controllers.Admin
{
    public class ProductManagerController : Controller
    {
        private readonly ILogger<ProductManagerController> _logger;
        private readonly ShoppingonlineContext _context;
        private readonly ProductService productService;

        public ProductManagerController(ILogger<ProductManagerController> logger, ShoppingonlineContext context)
        {
            _logger = logger;
            _context = context;
            productService = new ProductService(context);
        }

        public IActionResult Index(int currentPageIndex = 1)
        {
            ViewData["Title"] = "Product Manager";
            ViewData["Product"] = "active";
            return View("/Views/Admin/Product/ProductManager.cshtml", productService.GetProducts(currentPageIndex));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id)
        {
            var product = productService.FindProductById(id);
            bool isDelete = await productService.DeleteProduct(product);
            if (isDelete)
            {
                return Ok("Xóa sản phẩm thành công!");
            }
            else
            {
                return BadRequest("Xóa sản phẩm thất bại!");
            }
        }
    }
}
