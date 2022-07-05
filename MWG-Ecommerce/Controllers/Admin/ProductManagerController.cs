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
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MWG_Ecommerce.Controllers.Admin
{
    public class ProductManagerController : Controller
    {
        private readonly ILogger<ProductManagerController> _logger;
        private readonly ShoppingonlineContext _context;
        private readonly ProductService productService;
        private readonly ColorService colorService;
        private readonly SizeService sizeService;
        private readonly SupplierService supplierService;
        private readonly CategoryService categoryService;

        public ProductManagerController(ILogger<ProductManagerController> logger, ShoppingonlineContext context)
        {
            _logger = logger;
            _context = context;
            productService = new ProductService(context);
            colorService = new ColorService(context);
            sizeService = new SizeService(context);
            supplierService = new SupplierService(context);
            categoryService = new CategoryService(context);
        }

        public IActionResult Index(int pg = 1)
        {
            List<Product> products = _context.Products.ToList();

            const int pageSize = 10;
            if (pg < 1)
                pg = 1;

            int recsCount = products.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            List<Product> data = products.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            ViewData["Title"] = "Product Manager";
            ViewData["Product"] = "active";
            return View("/Views/Admin/Product/ProductManager.cshtml", data);
            //return View(data);
        }

        //public IActionResult Index(int page = 1)
        //{
        //    ViewData["Title"] = "Product Manager";
        //    ViewData["Product"] = "active";
        //    return View("/Views/Admin/Product/ProductManager.cshtml", productService.GetAllProduct().ToPagedList(page, 5));
        //}
        

        public ActionResult AddOrEditProduct(int id = 0)
        {

            ViewBag.Color = new SelectList(colorService.GetAllColor().OrderBy(n => n.Color1), "ColorId", "Color1");
            ViewBag.Size =  new SelectList (sizeService.GetAllSize().OrderBy(n=>n.Size1), "SizeId", "Size1");
            ViewBag.Supplier = new SelectList(supplierService.GetAllSupplier().OrderBy(n=>n.CompanyName), "SupplierId", "CompanyName");
            ViewBag.Category = new SelectList(categoryService.GetAllCategories().OrderBy(n=>n.CategoryName), "CategoryId", "CategoryName");

            if (id == 0)
            {
                return View("/Views/Admin/Product/AddOrEditProduct.cshtml", new Product());
            }
            else
            {
                var product = productService.FindProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View("/Views/Admin/Product/AddOrEditProduct.cshtml", product);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditProduct(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await productService.AddProduct(product);
                }
                else
                {
                    try
                    {
                        await productService.UpdateProduct(product);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (productService.FindProductById(id) == null)
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                
                return Ok("Thêm sản phẩm thành công!");
            }
            else
            {
                ViewBag.Color = new SelectList(colorService.GetAllColor().OrderBy(n => n.Color1), "ColorId", "Color1");
                ViewBag.Size = new SelectList(sizeService.GetAllSize().OrderBy(n => n.Size1), "SizeId", "Size1");
                ViewBag.Supplier = new SelectList(supplierService.GetAllSupplier().OrderBy(n => n.CompanyName), "SupplierId", "CompanyName");
                ViewBag.Category = new SelectList(categoryService.GetAllCategories().OrderBy(n => n.CategoryName), "CategoryId", "CategoryName");
                
                return View("/Views/Admin/Product/AddOrEditProduct.cshtml", product);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
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
