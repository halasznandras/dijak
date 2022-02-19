using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dijak.Data;
using dijak.Models;
using Microsoft.AspNetCore.Authorization;

namespace dijak.Controllers
{
    public class NobelDijakController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NobelDijakController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NobelDijak
        public async Task<IActionResult> Index(int? Ev, string Nev, string Tipus)
        {
            NobeldijakKeres elso = new NobeldijakKeres();
            var adatok = _context.NobelDij.Select(x=>x);
            if (Ev != 0 && Ev!=null)
                adatok = adatok.Where(x => x.Evszam == Ev);
            if (!string.IsNullOrEmpty(Nev))
                adatok = adatok.Where(x => x.KeresztNev.Contains(Nev) || x.VezetekNev.Contains(Nev));
            if (!string.IsNullOrEmpty(Tipus))
            {
                if (Tipus == "Szervezetek") adatok = adatok.Where(x => string.IsNullOrEmpty(x.VezetekNev));
                else adatok = adatok.Where(x => x.Tipus == Tipus);
            }
            elso.NobelDij = await adatok.ToListAsync();


                //elso.NobelDij = await _context.NobelDij.ToListAsync();
                elso.Tipusok = new SelectList(await _context.NobelDij.Select(x=>x.Tipus).Distinct().ToListAsync());


            return View(elso);
        }
      
        // GET: NobelDijak/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nobelDij = await _context.NobelDij
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nobelDij == null)
            {
                return NotFound();
            }

            return View(nobelDij);
        }

        [Authorize]
        // GET: NobelDijak/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: NobelDijak/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Evszam,Tipus,KeresztNev,VezetekNev")] NobelDij nobelDij)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nobelDij);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nobelDij);
        }

        [Authorize]
        // GET: NobelDijak/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nobelDij = await _context.NobelDij.FindAsync(id);
            if (nobelDij == null)
            {
                return NotFound();
            }
            return View(nobelDij);
        }

        [Authorize]
        // POST: NobelDijak/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Evszam,Tipus,KeresztNev,VezetekNev")] NobelDij nobelDij)
        {
            if (id != nobelDij.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nobelDij);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NobelDijExists(nobelDij.Id))
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
            return View(nobelDij);
        }

        [Authorize]
        // GET: NobelDijak/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nobelDij = await _context.NobelDij
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nobelDij == null)
            {
                return NotFound();
            }

            return View(nobelDij);
        }

        [Authorize]
        // POST: NobelDijak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nobelDij = await _context.NobelDij.FindAsync(id);
            _context.NobelDij.Remove(nobelDij);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NobelDijExists(int id)
        {
            return _context.NobelDij.Any(e => e.Id == id);
        }
    }
}
