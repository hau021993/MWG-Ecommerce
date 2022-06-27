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
    public class SupplierManagerController : Controller
    {
        private readonly ILogger<ProductManagerController> _logger;
        private readonly ShoppingonlineContext _context;
        private readonly SupplierService supplierService;

        public SupplierManagerController(ILogger<ProductManagerController> logger, ShoppingonlineContext context)
        {
            _logger = logger;
            _context = context;
            supplierService = new SupplierService(context);
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Supplier Manager";
            ViewData["Supplier"] = "active";
            return View("/Views/Admin/Supplier/SupplierManager.cshtml", supplierService.GetAllSupplier());
        }
    }
}
