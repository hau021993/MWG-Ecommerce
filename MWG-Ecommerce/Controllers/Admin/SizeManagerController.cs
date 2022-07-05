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
    public class SizeManagerController : Controller
    {
        private readonly ILogger<SizeManagerController> _logger;
        private readonly ShoppingonlineContext _context;
        private readonly SizeService sizeService;
        public SizeManagerController(ILogger<SizeManagerController> logger, ShoppingonlineContext context)
        {
            _logger = logger;
            _context = context;
            sizeService = new SizeService(context);
        }

        public IActionResult Index()
        {
            ViewData["Size"] = "active";
            return View("/Views/Admin/Size/SizeManager.cshtml", sizeService.GetAllSize());
        }

        public ActionResult AddOrEditSize(int id = 0)
        {
            if (id == 0)
            {
                return View("/Views/Admin/Size/AddOrEditSize.cshtml", new Size());
            }
            else
            {
                var size = sizeService.FindSizeById(id);
                if (size == null)
                {
                    return NotFound();
                }
                return View("/Views/Admin/Size/AddOrEditSize.cshtml", size);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditSize(int id, Size size)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await sizeService.AddSize(size);
                }
                else
                {
                    try
                    {
                        await sizeService.UpdateSize(size);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (sizeService.FindSizeById(id) == null)
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
                return View("/Views/Admin/Size/AddOrEditSize.cshtml", size);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var size = sizeService.FindSizeById(id);
            bool isDelete = await sizeService.DeleteSize(size);
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
