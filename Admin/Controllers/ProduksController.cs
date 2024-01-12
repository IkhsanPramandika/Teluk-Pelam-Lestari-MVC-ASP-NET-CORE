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
    public class ProduksController : Controller
    { 
        private readonly AdminContext _context;

        public ProduksController(AdminContext context)
        {
            _context = context;
        }

        // GET: Produks
        // GET: Produks
        // GET: Produks
        public async Task<IActionResult> Index()
        {
            var totalUdangKecil = await _context.Produk.CountAsync(p => p.Status == "Udang Kecil");
            var totalUdangSedang = await _context.Produk.CountAsync(p => p.Status == "Udang Sedang");
            var totalUdangBesar = await _context.Produk.CountAsync(p => p.Status == "Udang Besar");

            ViewBag.TotalUdangKecil = totalUdangKecil;
            ViewBag.TotalUdangSedang = totalUdangSedang;
            ViewBag.TotalUdangBesar = totalUdangBesar;

            return View(await _context.Produk.ToListAsync());
        }



        // GET: Produks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produk = await _context.Produk
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produk == null)
            {
                return NotFound();
            }

            return View(produk);
        }

        // GET: Produks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nama,Status,TotalProduk,ReleaseDate")] Produk produk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produk);
        }

        // GET: Produks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produk = await _context.Produk.FindAsync(id);
            if (produk == null)
            {
                return NotFound();
            }
            return View(produk);
        }

        // POST: Produks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nama,Status,TotalProduk,ReleaseDate")] Produk produk)
        {
            if (id != produk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdukExists(produk.Id))
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
            return View(produk);
        }

        // GET: Produks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produk = await _context.Produk
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produk == null)
            {
                return NotFound();
            }

            return View(produk);
        }

        // POST: Produks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produk = await _context.Produk.FindAsync(id);
            if (produk != null)
            {
                _context.Produk.Remove(produk);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdukExists(int id)
        {
            return _context.Produk.Any(e => e.Id == id);
        }

    }
}
