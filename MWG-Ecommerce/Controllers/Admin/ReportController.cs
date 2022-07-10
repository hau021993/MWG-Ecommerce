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
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> _logger;
        private readonly ShoppingonlineContext _context;
        private readonly ReportService reportService;
        private readonly ProductService productService;
        private readonly ColorService colorService;
        private readonly SizeService sizeService;
        private readonly SupplierService supplierService;
        private readonly CategoryService categoryService;

        public ReportController(ILogger<ReportController> logger, ShoppingonlineContext context)
        {
            _logger = logger;
            _context = context;
            reportService = new ReportService(context);
            productService = new ProductService(context);
            colorService = new ColorService(context);
            sizeService = new SizeService(context);
            supplierService = new SupplierService(context);
            categoryService = new CategoryService(context);
        }

        public IActionResult OrderReport(DateTime fromDate, DateTime toDate)
        {
            ViewData["GetCountOrderByDate"] = reportService.GetCountOrderByDate(fromDate, toDate);
            ViewData["GetCountUserByDate"] = reportService.GetCountUserByDate(fromDate, toDate);
            ViewData["GetTotalMoneyOrderByDate"] = reportService.GetTotalMoneyOrderByDate(fromDate, toDate);
            ViewData["GetAllTotalMoney"] = reportService.GetAllTotalMoney();
            ViewData["OrderReport"] = "active";
            return View("/Views/Admin/Report/OrderReport.cshtml", reportService.GetAllOrder(fromDate, toDate));
        }

        public IActionResult ProductReport(DateTime fromDate, DateTime toDate)
        {            
            ViewData["GetCountProductByDate"] = reportService.GetCountProductByDate(fromDate, toDate);
            ViewData["GetSumQuanlityProductByDate"] = reportService.GetSumQuanlityProductByDate(fromDate, toDate);
            ViewData["GetTotalMoneyOrderByDate"] = reportService.GetTotalMoneyOrderByDate(fromDate, toDate);
            ViewData["GetAllCountProduct"] = reportService.GetAllCountProduct();
            ViewData["GetAllSumQuanlityProduct"] = reportService.GetAllSumQuanlityProduct();
            ViewData["GetAllTotalMoney"] = reportService.GetAllTotalMoney();
            ViewData["ProductReport"] = "active";
            return View("/Views/Admin/Report/ProductReport.cshtml", reportService.GetAllProduct(fromDate, toDate));
        }

        public ActionResult DetailProduct(int id)
        {

            ViewBag.Color = new SelectList(colorService.GetAllColor().OrderBy(n => n.Color1), "ColorId", "Color1");
            ViewBag.Size = new SelectList(sizeService.GetAllSize().OrderBy(n => n.Size1), "SizeId", "Size1");
            ViewBag.Supplier = new SelectList(supplierService.GetAllSupplier().OrderBy(n => n.CompanyName), "SupplierId", "CompanyName");
            ViewBag.Category = new SelectList(categoryService.GetAllCategories().OrderBy(n => n.CategoryName), "CategoryId", "CategoryName");

            var product = productService.FindProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View("/Views/Admin/Report/DetailProduct.cshtml", product);            
        }            
    }
}
