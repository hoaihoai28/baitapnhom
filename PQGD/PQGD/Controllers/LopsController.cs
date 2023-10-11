using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PQGD.Data;
using PQGD.Models;

namespace PQGD.Controllers
{
    public class LopsController : Controller
    {
        private readonly data_context _context;

        public LopsController(data_context context)
        {
            _context = context;
        }

        // GET: Lops
        public async Task<IActionResult> Index()
        {
              return _context.Lops != null ? 
                          View(await _context.Lops.ToListAsync()) :
                          Problem("Entity set 'data_context.Lops'  is null.");
        }

        // GET: Lops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lops == null)
            {
                return NotFound();
            }

            var lop = await _context.Lops
                .FirstOrDefaultAsync(m => m.id_lop == id);
            if (lop == null)
            {
                return NotFound();
            }

            return View(lop);
        }

        // GET: Lops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_lop,tenlop")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lop);
        }

        // GET: Lops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lops == null)
            {
                return NotFound();
            }

            var lop = await _context.Lops.FindAsync(id);
            if (lop == null)
            {
                return NotFound();
            }
            return View(lop);
        }

        // POST: Lops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_lop,tenlop")] Lop lop)
        {
            if (id != lop.id_lop)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopExists(lop.id_lop))
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
            return View(lop);
        }

        // GET: Lops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lops == null)
            {
                return NotFound();
            }

            var lop = await _context.Lops
                .FirstOrDefaultAsync(m => m.id_lop == id);
            if (lop == null)
            {
                return NotFound();
            }

            return View(lop);
        }

        // POST: Lops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lops == null)
            {
                return Problem("Entity set 'data_context.Lops'  is null.");
            }
            var lop = await _context.Lops.FindAsync(id);
            if (lop != null)
            {
                _context.Lops.Remove(lop);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopExists(int id)
        {
          return (_context.Lops?.Any(e => e.id_lop == id)).GetValueOrDefault();
        }
    }
}
