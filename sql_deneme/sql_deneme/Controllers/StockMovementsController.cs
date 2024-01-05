using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sql_deneme.Models;

namespace sql_deneme.Controllers
{
    [Authorize]
    public class StockMovementsController : Controller
    {
        private readonly SqldenemeContext _context;

        public StockMovementsController(SqldenemeContext context)
        {
            _context = context;
        }

        // GET: StockMovements
        public async Task<IActionResult> Index()
        {
            var sqldenemeContext = _context.StockMovements.Include(s => s.Product);
            return View(await sqldenemeContext.ToListAsync());
        }

        // GET: StockMovements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ModelState.Clear();
            if (id == null || _context.StockMovements == null)
            {
                return NotFound();
            }

            var stockMovement = await _context.StockMovements
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.StockMovementId == id);
            if (stockMovement == null)
            {
                return NotFound();
            }

            return View(stockMovement);
        }


        // GET: StockMovements/Create
        public IActionResult Create()
        {
            ModelState.Clear();
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return View();
        }

        // POST: StockMovements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockMovementId,ProductId,Quantity,MovementDate")] StockMovement stockMovement)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                _context.Add(stockMovement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // RedirectToAction("Index", "StockMovements");
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", stockMovement.ProductId);
            return View(stockMovement);
        }


        // GET: StockMovements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ModelState.Clear();
            if (id == null || _context.StockMovements == null)
            {
                return NotFound();
            }

            var stockMovement = await _context.StockMovements.FindAsync(id);
            if (stockMovement == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", stockMovement.ProductId);
            return View(stockMovement);
        }

        // POST: StockMovements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockMovementId,ProductId,Quantity,MovementDate")] StockMovement stockMovement)
        {
            ModelState.Clear();
            if (id != stockMovement.StockMovementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockMovement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockMovementExists(stockMovement.StockMovementId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", stockMovement.ProductId);
            return View(stockMovement);
        }

        // GET: StockMovements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ModelState.Clear();
            if (id == null || _context.StockMovements == null)
            {
                return NotFound();
            }

            var stockMovement = await _context.StockMovements
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.StockMovementId == id);
            if (stockMovement == null)
            {
                return NotFound();
            }

            return View(stockMovement);
        }

        // POST: StockMovements/Delete/5
        // POST: StockMovements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ModelState.Clear();
            if (_context.StockMovements == null)
            {
                return Problem("Entity set 'SqldenemeContext.StockMovements'  is null.");
            }
            var stockMovement = await _context.StockMovements.FindAsync(id);
            if (stockMovement != null)
            {
                _context.StockMovements.Remove(stockMovement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // RedirectToAction("Index", "StockMovements");
            }

            return NotFound();
        }


        private bool StockMovementExists(int id)
        {
          return (_context.StockMovements?.Any(e => e.StockMovementId == id)).GetValueOrDefault();
        }
    }
}
