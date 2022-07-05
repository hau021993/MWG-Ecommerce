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
        private readonly ILogger<SupplierManagerController> _logger;
        private readonly ShoppingonlineContext _context;
        private readonly SupplierService supplierService;

        public SupplierManagerController(ILogger<SupplierManagerController> logger, ShoppingonlineContext context)
        {
            _logger = logger;
            _context = context;
            supplierService = new SupplierService(context);
        }
        public IActionResult Index()
        {
            //List<Supplier> suppliers = new List<Supplier>();
            ViewData["Supplier"] = "active";
            return View("/Views/Admin/Supplier/SupplierManager.cshtml", supplierService.GetAllSupplier());
        }

        public ActionResult AddOrEditSupplier(int id = 0)
        {
            if (id == 0)
            {
                return View("/Views/Admin/Supplier/AddOrEditSupplier.cshtml", new Supplier());
            }
            else
            {
                var supplier = supplierService.FindSupplierById(id);
                if (supplier == null)
                {
                    return NotFound();
                }
                return View("/Views/Admin/Supplier/AddOrEditSupplier.cshtml", supplier);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditSupplier(int id, Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await supplierService.AddSupplier(supplier);
                }
                else
                {
                    try
                    {
                        await supplierService.UpdateSupplier(supplier);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (supplierService.FindSupplierById(id) == null)
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return Ok("Thêm thành công!");
            }
            else
            {
                return View("/Views/Admin/Supplier/AddOrEditSupplier.cshtml", supplier);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var supplier = supplierService.FindSupplierById(id);
            bool isDelete = await supplierService.DeleteSupplier(supplier);
            if (isDelete)
            {
                return Ok("Xóa đối tượng thành công!");
            }
            else
            {
                return BadRequest("Xóa đối tượng thất bại!");
            }
        }
    }
}
