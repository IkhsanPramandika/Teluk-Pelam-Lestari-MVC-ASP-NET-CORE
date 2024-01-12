using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Admin.Data;
using Admin.Models;

namespace Admin.Controllers
{
    public class KarirsController : Controller
    {
        private readonly AdminContext _context;

        public KarirsController(AdminContext context)
        {
            _context = context;
        }

        // GET: Karirs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Karir.ToListAsync());
        }

        // GET: Karirs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karir = await _context.Karir
                .FirstOrDefaultAsync(m => m.Id == id);
            if (karir == null)
            {
                return NotFound();
            }

            return View(karir);
        }

        // GET: Karirs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Karirs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nama,email,Jabatan,Berkas")] Karir karir)
        {
            if (ModelState.IsValid)
            {
                _context.Add(karir);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(karir);
        }

        // GET: Karirs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karir = await _context.Karir.FindAsync(id);
            if (karir == null)
            {
                return NotFound();
            }
            return View(karir);
        }

        // POST: Karirs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nama,email,Jabatan,Berkas")] Karir karir)
        {
            if (id != karir.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(karir);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KarirExists(karir.Id))
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
            return View(karir);
        }

        // GET: Karirs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karir = await _context.Karir
                .FirstOrDefaultAsync(m => m.Id == id);
            if (karir == null)
            {
                return NotFound();
            }

            return View(karir);
        }

        // POST: Karirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var karir = await _context.Karir.FindAsync(id);
            if (karir != null)
            {
                _context.Karir.Remove(karir);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KarirExists(int id)
        {
            return _context.Karir.Any(e => e.Id == id);
        }
    }
}
