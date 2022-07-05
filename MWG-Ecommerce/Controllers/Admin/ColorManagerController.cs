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
    public class ColorManagerController : Controller
    {
        private readonly ILogger<ColorManagerController> _logger;
        private readonly ShoppingonlineContext _context;
        private readonly ColorService colorService;
        public ColorManagerController(ILogger<ColorManagerController> logger, ShoppingonlineContext context)
        {
            _logger = logger;
            _context = context;
            colorService = new ColorService(context);
        }

        public IActionResult Index(int pg = 1)
        {
            const int pageSize = 10;
            if (pg < 1)
                pg = 1;

            int recsCount = _context.Colors.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            List<Color> data = _context.Colors.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            ViewData["Color"] = "active";
            return View("/Views/Admin/Color/ColorManager.cshtml", data);
        }

        public ActionResult AddOrEditColor(int id = 0)
        {
            if (id == 0)
            {
                return View("/Views/Admin/Color/AddOrEditColor.cshtml", new Color());
            }
            else
            {
                var color = colorService.FindColorById(id);
                if (color == null)
                {
                    return NotFound();
                }
                return View("/Views/Admin/Color/AddOrEditColor.cshtml", color);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditColor(int id, Color color)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await colorService.AddColor(color);
                }
                else
                {
                    try
                    {
                        await colorService.UpdateColor(color);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (colorService.FindColorById(id) == null)
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
                return View("/Views/Admin/Color/AddOrEditColor.cshtml", color);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var color = colorService.FindColorById(id);
            bool isDelete = await colorService.DeleteColor(color);
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
