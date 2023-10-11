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
    public class HocKiesController : Controller
    {
        private readonly data_context _context;

        public HocKiesController(data_context context)
        {
            _context = context;
        }

        // GET: HocKies
        public async Task<IActionResult> Index()
        {
              return _context.HocKys != null ? 
                          View(await _context.HocKys.ToListAsync()) :
                          Problem("Entity set 'data_context.HocKys'  is null.");
        }

        // GET: HocKies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HocKys == null)
            {
                return NotFound();
            }

            var hocKy = await _context.HocKys
                .FirstOrDefaultAsync(m => m.Id_hocky == id);
            if (hocKy == null)
            {
                return NotFound();
            }

            return View(hocKy);
        }

        // GET: HocKies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HocKies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_hocky,tenhocky,namhoc")] HocKy hocKy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hocKy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hocKy);
        }

        // GET: HocKies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HocKys == null)
            {
                return NotFound();
            }

            var hocKy = await _context.HocKys.FindAsync(id);
            if (hocKy == null)
            {
                return NotFound();
            }
            return View(hocKy);
        }

        // POST: HocKies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_hocky,tenhocky,namhoc")] HocKy hocKy)
        {
            if (id != hocKy.Id_hocky)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hocKy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HocKyExists(hocKy.Id_hocky))
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
            return View(hocKy);
        }

        // GET: HocKies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HocKys == null)
            {
                return NotFound();
            }

            var hocKy = await _context.HocKys
                .FirstOrDefaultAsync(m => m.Id_hocky == id);
            if (hocKy == null)
            {
                return NotFound();
            }

            return View(hocKy);
        }

        // POST: HocKies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HocKys == null)
            {
                return Problem("Entity set 'data_context.HocKys'  is null.");
            }
            var hocKy = await _context.HocKys.FindAsync(id);
            if (hocKy != null)
            {
                _context.HocKys.Remove(hocKy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HocKyExists(int id)
        {
          return (_context.HocKys?.Any(e => e.Id_hocky == id)).GetValueOrDefault();
        }
    }
}
