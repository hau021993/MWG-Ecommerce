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
    public class LoginHistoriesController : Controller
    {
        private readonly ShoppingonlineContext _context;

        public LoginHistoriesController(ShoppingonlineContext context)
        {
            _context = context;
        }

        // GET: LoginHistories
        public async Task<IActionResult> Index()
        {
            var shoppingonlineContext = _context.LoginHistories.Include(l => l.User);
            return View(await shoppingonlineContext.ToListAsync());
        }

        // GET: LoginHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginHistory = await _context.LoginHistories
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.HistoryId == id);
            if (loginHistory == null)
            {
                return NotFound();
            }

            return View(loginHistory);
        }

        // GET: LoginHistories/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Name");
            return View();
        }

        // POST: LoginHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoryId,UserId,Time")] LoginHistory loginHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Name", loginHistory.UserId);
            return View(loginHistory);
        }

        // GET: LoginHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginHistory = await _context.LoginHistories.FindAsync(id);
            if (loginHistory == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Name", loginHistory.UserId);
            return View(loginHistory);
        }

        // POST: LoginHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoryId,UserId,Time")] LoginHistory loginHistory)
        {
            if (id != loginHistory.HistoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginHistoryExists(loginHistory.HistoryId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Name", loginHistory.UserId);
            return View(loginHistory);
        }

        // GET: LoginHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginHistory = await _context.LoginHistories
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.HistoryId == id);
            if (loginHistory == null)
            {
                return NotFound();
            }

            return View(loginHistory);
        }

        // POST: LoginHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loginHistory = await _context.LoginHistories.FindAsync(id);
            _context.LoginHistories.Remove(loginHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginHistoryExists(int id)
        {
            return _context.LoginHistories.Any(e => e.HistoryId == id);
        }
    }
}
