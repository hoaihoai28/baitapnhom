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
    public class GiaoViensController : Controller
    {
        private readonly data_context _context;

        public GiaoViensController(data_context context)
        {
            _context = context;
        }

        // GET: GiaoViens
        public async Task<IActionResult> Index()
        {
              return _context.GiaoViens != null ? 
                          View(await _context.GiaoViens.ToListAsync()) :
                          Problem("Entity set 'data_context.GiaoViens'  is null.");

        }

        // GET: GiaoViens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GiaoViens == null)
            {
                return NotFound();
            }

            var giaoVien = await _context.GiaoViens
                .FirstOrDefaultAsync(m => m.id_giaovien == id);
            if (giaoVien == null)
            {
                return NotFound();
            }

            return View(giaoVien);
        }

        // GET: GiaoViens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GiaoViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_giaovien,hoten,gioitinh,ngaysinh,sdt,email,takhoan,matkhau,admin")] GiaoVien giaoVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giaoVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giaoVien);
        }

        // GET: GiaoViens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GiaoViens == null)
            {
                return NotFound();
            }

            var giaoVien = await _context.GiaoViens.FindAsync(id);
            if (giaoVien == null)
            {
                return NotFound();
            }
            return View(giaoVien);
        }

        // POST: GiaoViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_giaovien,hoten,gioitinh,ngaysinh,sdt,email,takhoan,matkhau,admin")] GiaoVien giaoVien)
        {
            if (id != giaoVien.id_giaovien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giaoVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiaoVienExists(giaoVien.id_giaovien))
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
            return View(giaoVien);
        }

        // GET: GiaoViens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GiaoViens == null)
            {
                return NotFound();
            }

            var giaoVien = await _context.GiaoViens
                .FirstOrDefaultAsync(m => m.id_giaovien == id);
            if (giaoVien == null)
            {
                return NotFound();
            }

            return View(giaoVien);
        }

        // POST: GiaoViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GiaoViens == null)
            {
                return Problem("Entity set 'data_context.GiaoViens'  is null.");
            }
            var giaoVien = await _context.GiaoViens.FindAsync(id);
            if (giaoVien != null)
            {
                _context.GiaoViens.Remove(giaoVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiaoVienExists(int id)
        {
          return (_context.GiaoViens?.Any(e => e.id_giaovien == id)).GetValueOrDefault();
        }
    }
}
