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
    public class PhanQuyensController : Controller
    {
        private readonly data_context _context;

        public PhanQuyensController(data_context context)
        {
            _context = context;
        }

        // GET: PhanQuyens
        public async Task<IActionResult> Index()
        {
            var data_context = _context.PhanQuyens.Include(p => p.GiaoVien).Include(p => p.HocKy).Include(p => p.Lop).Include(p => p.MonHoc);
            return View(await data_context.ToListAsync());
          
        }

        // GET: PhanQuyens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PhanQuyens == null)
            {
                return NotFound();
            }

            var phanQuyen = await _context.PhanQuyens
                .Include(p => p.GiaoVien)
                .Include(p => p.HocKy)
                .Include(p => p.Lop)
                .Include(p => p.MonHoc)
                .FirstOrDefaultAsync(m => m.id_phanquyen == id);
            if (phanQuyen == null)
            {
                return NotFound();
            }

            return View(phanQuyen);
        }

        // GET: PhanQuyens/Create
        public IActionResult Create()
        {
            ViewData["id_giaovien"] = new SelectList(_context.GiaoViens, "id_giaovien", "id_giaovien");
            ViewData["id_hocky"] = new SelectList(_context.HocKys, "Id_hocky", "Id_hocky");
            ViewData["id_lop"] = new SelectList(_context.Lops, "id_lop", "id_lop");
            ViewData["id_monhoc"] = new SelectList(_context.MonHocs, "id_monhoc", "id_monhoc");
            return View();
        }

        // POST: PhanQuyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_phanquyen,id_giaovien,id_lop,id_monhoc,id_hocky")] PhanQuyen phanQuyen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phanQuyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_giaovien"] = new SelectList(_context.GiaoViens, "id_giaovien", "id_giaovien", phanQuyen.id_giaovien);
            ViewData["id_hocky"] = new SelectList(_context.HocKys, "Id_hocky", "Id_hocky", phanQuyen.id_hocky);
            ViewData["id_lop"] = new SelectList(_context.Lops, "id_lop", "id_lop", phanQuyen.id_lop);
            ViewData["id_monhoc"] = new SelectList(_context.MonHocs, "id_monhoc", "id_monhoc", phanQuyen.id_monhoc);
            return View(phanQuyen);
        }

        // GET: PhanQuyens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PhanQuyens == null)
            {
                return NotFound();
            }

            var phanQuyen = await _context.PhanQuyens.FindAsync(id);
            if (phanQuyen == null)
            {
                return NotFound();
            }
            ViewData["id_giaovien"] = new SelectList(_context.GiaoViens, "id_giaovien", "id_giaovien", phanQuyen.id_giaovien);
            ViewData["id_hocky"] = new SelectList(_context.HocKys, "Id_hocky", "Id_hocky", phanQuyen.id_hocky);
            ViewData["id_lop"] = new SelectList(_context.Lops, "id_lop", "id_lop", phanQuyen.id_lop);
            ViewData["id_monhoc"] = new SelectList(_context.MonHocs, "id_monhoc", "id_monhoc", phanQuyen.id_monhoc);
            return View(phanQuyen);
        }

        // POST: PhanQuyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_phanquyen,id_giaovien,id_lop,id_monhoc,id_hocky")] PhanQuyen phanQuyen)
        {
            if (id != phanQuyen.id_phanquyen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phanQuyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhanQuyenExists(phanQuyen.id_phanquyen))
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
            ViewData["id_giaovien"] = new SelectList(_context.GiaoViens, "id_giaovien", "id_giaovien", phanQuyen.id_giaovien);
            ViewData["id_hocky"] = new SelectList(_context.HocKys, "Id_hocky", "Id_hocky", phanQuyen.id_hocky);
            ViewData["id_lop"] = new SelectList(_context.Lops, "id_lop", "id_lop", phanQuyen.id_lop);
            ViewData["id_monhoc"] = new SelectList(_context.MonHocs, "id_monhoc", "id_monhoc", phanQuyen.id_monhoc);
            return View(phanQuyen);
        }

        // GET: PhanQuyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PhanQuyens == null)
            {
                return NotFound();
            }

            var phanQuyen = await _context.PhanQuyens
                .Include(p => p.GiaoVien)
                .Include(p => p.HocKy)
                .Include(p => p.Lop)
                .Include(p => p.MonHoc)
                .FirstOrDefaultAsync(m => m.id_phanquyen == id);
            if (phanQuyen == null)
            {
                return NotFound();
            }

            return View(phanQuyen);
        }

        // POST: PhanQuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PhanQuyens == null)
            {
                return Problem("Entity set 'data_context.PhanQuyens'  is null.");
            }
            var phanQuyen = await _context.PhanQuyens.FindAsync(id);
            if (phanQuyen != null)
            {
                _context.PhanQuyens.Remove(phanQuyen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhanQuyenExists(int id)
        {
          return (_context.PhanQuyens?.Any(e => e.id_phanquyen == id)).GetValueOrDefault();
        }
    }
}
