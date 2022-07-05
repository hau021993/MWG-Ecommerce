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
    public class CategoryManagerController : Controller
    {
        private readonly ILogger<CategoryManagerController> _logger;
        private readonly ShoppingonlineContext _context;
        private readonly CategoryService categoryService;

        public CategoryManagerController(ILogger<CategoryManagerController> logger, ShoppingonlineContext context)
        {
            _logger = logger;
            _context = context;
            categoryService = new CategoryService(context);
        }

        public IActionResult Index()
        {
            ViewData["Category"] = "active";
            return View("/Views/Admin/Category/CategoryManager.cshtml", categoryService.GetAllCategories());
        }

        public ActionResult AddOrEditCategory(int id = 0)
        {
            if (id == 0)
            {
                return View("/Views/Admin/Category/AddOrEditCategory.cshtml", new Category());
            }
            else
            {
                var categories = categoryService.FindCategoryById(id);
                if (categories == null)
                {
                    return NotFound();
                }
                return View("/Views/Admin/Category/AddOrEditCategory.cshtml", categories);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEditCategory(int id, Category categories)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await categoryService.AddCategory(categories);
                }
                else
                {
                    try
                    {
                        await categoryService.UpdateCategory(categories);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (categoryService.FindCategoryById(id) == null)
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
                return View("/Views/Admin/Category/AddOrEditCategory.cshtml", categories);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var categories = categoryService.FindCategoryById(id);
            bool isDelete = await categoryService.DeleteCategory(categories);
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
