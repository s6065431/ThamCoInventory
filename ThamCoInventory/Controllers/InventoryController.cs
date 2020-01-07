using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventorydata.data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ThamCoInventory.Controllers
{
    public class InventoryController : Controller
    {
        private readonly InventoryDbContext _context;

        public InventoryController(InventoryDbContext context)
        {
            _context = context;
        }

        // GET: Inventory
        public async Task<IActionResult> Index()
        {
            return View(await _context.StockRequests.ToListAsync());
        }

        // GET: Inventory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockRequest = await _context.StockRequests
                                             .FirstOrDefaultAsync(s => s.ID == id);

            if (stockRequest == null)
            {
                return NotFound();
            }

            return View(stockRequest);
        }

        // GET: Inventory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, ProductID, StaffID, RequestedQuantity, ApprovalStatus")] StockRequest stockRequest)
        {
            if (ModelState.IsValid)
            {
                stockRequest.ProductID = 1;
                stockRequest.StaffID = 1;
                _context.Add(stockRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockRequest);
        }

        // GET: Inventory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockRequest = await _context.StockRequests.FindAsync(id);
            if (stockRequest == null)
            {
                return NotFound();
            }
            return View(stockRequest);
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestedQuantity, ApprovalStatus, ID, ProductID, StaffID")] StockRequest stockRequest)
        {
            if (id != stockRequest.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockRequestExists(stockRequest.ID))
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
            return View(stockRequest);
        }

        // GET: Inventory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockRequest = await _context.StockRequests
                                             .FirstOrDefaultAsync(s => s.ID == id);
            if (stockRequest == null)
            {
                return NotFound();
            }
            return View(stockRequest);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockRequest = await _context.StockRequests.FindAsync(id);
            _context.StockRequests.Remove(stockRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool StockRequestExists(int id)
        {
            return _context.StockRequests.Any(s => s.ID == id);
        }
    }
}
