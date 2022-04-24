using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlkatreszRaktar.Data;
using AlkatreszRaktar.Models;
using Microsoft.AspNetCore.Authorization;

namespace AlkatreszRaktar.Controllers
{
    public class AlkatreszekController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlkatreszekController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alkatreszek
        public async Task<IActionResult> Index(string MegnevezesKeres, string TipusKeres)
        {
            Kereses ujKereses = new Kereses();
            var alkatresz = _context.Alkatresz.Select(x => x);

            if (!string.IsNullOrEmpty(MegnevezesKeres))
            {
                ujKereses.MegnevezesKeres = MegnevezesKeres;
                alkatresz = alkatresz.Where(x => x.Megnevezes.Contains(MegnevezesKeres));
            }

            if (!string.IsNullOrEmpty(TipusKeres))
            {
                ujKereses.TipusKeres = TipusKeres;
                alkatresz = alkatresz.Where(x => x.Tipus.Equals(TipusKeres));
            }

            //ujKereses.KategoriaLista = new SelectList(await _context.Adomany.Select(x => x.Kategoria).Distinct().ToListAsync());
            //ujKereses.AdomanyLista = await adomanyok.ToListAsync();

            ujKereses.TipusLista = new SelectList(await _context.Alkatresz.Select(x => x.Tipus).Distinct().ToListAsync());
            ujKereses.AlkatreszLista = await alkatresz.ToListAsync();

            return View(ujKereses);
        }

        // GET: Alkatreszek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alkatresz = await _context.Alkatresz
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alkatresz == null)
            {
                return NotFound();
            }

            return View(alkatresz);
        }

        // GET: Alkatreszek/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alkatreszek/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Megnevezes,Gyarto,Tipus,BeszerzesiAr")] Alkatresz alkatresz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alkatresz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alkatresz);
        }

        // GET: Alkatreszek/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alkatresz = await _context.Alkatresz.FindAsync(id);
            if (alkatresz == null)
            {
                return NotFound();
            }
            return View(alkatresz);
        }

        // POST: Alkatreszek/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Megnevezes,Gyarto,Tipus,BeszerzesiAr")] Alkatresz alkatresz)
        {
            if (id != alkatresz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alkatresz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlkatreszExists(alkatresz.Id))
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
            return View(alkatresz);
        }

        // GET: Alkatreszek/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alkatresz = await _context.Alkatresz
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alkatresz == null)
            {
                return NotFound();
            }

            return View(alkatresz);
        }

        // POST: Alkatreszek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alkatresz = await _context.Alkatresz.FindAsync(id);
            _context.Alkatresz.Remove(alkatresz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlkatreszExists(int id)
        {
            return _context.Alkatresz.Any(e => e.Id == id);
        }
    }
}
