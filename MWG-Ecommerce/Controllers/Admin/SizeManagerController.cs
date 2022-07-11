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
        public const int ITEMS_PER_PAGE = 10;

        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { get; set; }
        public int countPages { get; set; }
        public SizeManagerController(ILogger<SizeManagerController> logger, ShoppingonlineContext context)
        {
            _logger = logger;
            _context = context;
            sizeService = new SizeService(context);
        }

        //public async Task <IActionResult> Index([FromQuery(Name = "p")] int currentPage, int pagesize)
        //{
        //    var sizes = _context.Sizes.OrderBy(s => s.Size1);
        //    int totalSizes = await sizes.CountAsync();
        //    int countPages = (int)Math.Ceiling((double)totalSizes / pagesize);
        //    if(currentPage > countPages) currentPage = countPages;
        //    if(countPages < 1) currentPage = 1;

        //    var pagingModel = new PagingModel()
        //    {
        //        countpages = countPages, 
        //        currentpage = currentPage,
        //        generateUrl = (pageNumber) => Url.Action("Index", new
        //        {
        //            p = pageNumber,
        //            pagesize = pagesize
        //        })
        //    };

        //    ViewBag.pagingModel = pagingModel;
        //    ViewBag.totalSizes = totalSizes;

        //    var sizesInPage = await sizes.Skip((currentPage - 1) * pagesize)
        //                      .Take(pagesize).ToListAsync();
        //    ViewData["Size"] = "active";
        //    return View("/Views/Admin/Size/SizeManager.cshtml", sizesInPage);
        //}

        public IActionResult Index(int currentPageIndex = 1)
        {            
            ViewData["Size"] = "active";
            return View("/Views/Admin/Size/SizeManager.cshtml", sizeService.GetSizes(currentPageIndex));
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
