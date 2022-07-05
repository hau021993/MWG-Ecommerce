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
    public class DiscountManagerController : Controller
    {
        private readonly ILogger<DiscountManagerController> _logger;
        private readonly ShoppingonlineContext _context;
        private readonly DiscountService discountService;

        public DiscountManagerController(ILogger<DiscountManagerController> logger, ShoppingonlineContext context)
        {
            _logger = logger;
            _context = context;
            discountService = new DiscountService(context);
        }

        public IActionResult Index()
        {
            ViewData["Discount"] = "active";
            return View("/Views/Admin/Discount/DiscountManager.cshtml", discountService.GetAllDiscount());
        }

        public ActionResult AddOrEditDiscount(int id = 0)
        {
            if (id == 0)
            {
                return View("/Views/Admin/Discount/AddOrEditDiscount.cshtml", new Discount());
            }
            else
            {
                var discount = discountService.FindDiscountById(id);
                if (discount == null)
                {
                    return NotFound();
                }
                return View("/Views/Admin/Discount/AddOrEditDiscount.cshtml", discount);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditDiscount(int id, Discount discount)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await discountService.AddDiscount(discount);
                }
                else
                {
                    try
                    {
                        await discountService.UpdateDiscount(discount);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (discountService.FindDiscountById(id) == null)
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
                return View("/Views/Admin/Discount/AddOrEditDiscount.cshtml", discount);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var discount = discountService.FindDiscountById(id);
            bool isDelete = await discountService.DeleteDiscount(discount);
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
