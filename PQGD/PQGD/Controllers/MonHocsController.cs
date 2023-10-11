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
    public class MonHocsController : Controller
    {
        private readonly data_context _context;

        public MonHocsController(data_context context)
        {
            _context = context;
        }

        // GET: MonHocs
        public async Task<IActionResult> Index()
        {
              return _context.MonHocs != null ? 
                          View(await _context.MonHocs.ToListAsync()) :
                          Problem("Entity set 'data_context.MonHocs'  is null.");
        }

        // GET: MonHocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MonHocs == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHocs
                .FirstOrDefaultAsync(m => m.id_monhoc == id);
            if (monHoc == null)
            {
                return NotFound();
            }

            return View(monHoc);
        }

        // GET: MonHocs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MonHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_monhoc,tenmonhoc")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monHoc);
        }

        // GET: MonHocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MonHocs == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHocs.FindAsync(id);
            if (monHoc == null)
            {
                return NotFound();
            }
            return View(monHoc);
        }

        // POST: MonHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_monhoc,tenmonhoc")] MonHoc monHoc)
        {
            if (id != monHoc.id_monhoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonHocExists(monHoc.id_monhoc))
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
            return View(monHoc);
        }

        // GET: MonHocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MonHocs == null)
            {
                return NotFound();
            }

            var monHoc = await _context.MonHocs
                .FirstOrDefaultAsync(m => m.id_monhoc == id);
            if (monHoc == null)
            {
                return NotFound();
            }

            return View(monHoc);
        }

        // POST: MonHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MonHocs == null)
            {
                return Problem("Entity set 'data_context.MonHocs'  is null.");
            }
            var monHoc = await _context.MonHocs.FindAsync(id);
            if (monHoc != null)
            {
                _context.MonHocs.Remove(monHoc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonHocExists(int id)
        {
          return (_context.MonHocs?.Any(e => e.id_monhoc == id)).GetValueOrDefault();
        }
    }
}
