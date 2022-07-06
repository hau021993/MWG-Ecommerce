using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MWG_Ecommerce.Data;
using MWG_Ecommerce.Models;

namespace MWG_Ecommerce.Controllers
{
    public class DiscountDetailsController : Controller
    {
        private readonly ShoppingonlineContext _context;

        public DiscountDetailsController(ShoppingonlineContext context)
        {
            _context = context;
        }

        // GET: DiscountDetails
        public async Task<IActionResult> Index()
        {
            var shoppingonlineContext = _context.DiscountDetails.Include(d => d.Discount).Include(d => d.Product);
            return View(await shoppingonlineContext.ToListAsync());
        }

        // GET: DiscountDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountDetail = await _context.DiscountDetails
                .Include(d => d.Discount)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (discountDetail == null)
            {
                return NotFound();
            }

            return View(discountDetail);
        }

        // GET: DiscountDetails/Create
        public IActionResult Create()
        {
            ViewData["DiscountId"] = new SelectList(_context.Discounts, "DiscountId", "DiscountId");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Picture");
            return View();
        }

        // POST: DiscountDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,DiscountId")] DiscountDetail discountDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discountDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiscountId"] = new SelectList(_context.Discounts, "DiscountId", "DiscountId", discountDetail.DiscountId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Picture", discountDetail.ProductId);
            return View(discountDetail);
        }

        // GET: DiscountDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountDetail = await _context.DiscountDetails.FindAsync(id);
            if (discountDetail == null)
            {
                return NotFound();
            }
            ViewData["DiscountId"] = new SelectList(_context.Discounts, "DiscountId", "DiscountId", discountDetail.DiscountId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Picture", discountDetail.ProductId);
            return View(discountDetail);
        }

        // POST: DiscountDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,DiscountId")] DiscountDetail discountDetail)
        {
            if (id != discountDetail.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discountDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscountDetailExists(discountDetail.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiscountId"] = new SelectList(_context.Discounts, "DiscountId", "DiscountId", discountDetail.DiscountId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Picture", discountDetail.ProductId);
            return View(discountDetail);
        }

        // GET: DiscountDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountDetail = await _context.DiscountDetails
                .Include(d => d.Discount)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (discountDetail == null)
            {
                return NotFound();
            }

            return View(discountDetail);
        }

        // POST: DiscountDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discountDetail = await _context.DiscountDetails.FindAsync(id);
            _context.DiscountDetails.Remove(discountDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscountDetailExists(int id)
        {
            return _context.DiscountDetails.Any(e => e.ProductId == id);
        }
    }
}
