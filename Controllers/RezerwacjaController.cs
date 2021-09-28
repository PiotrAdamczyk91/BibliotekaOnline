using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotekaOnline.Data;
using BibliotekaOnline.Models;

namespace BibliotekaOnline.Controllers
{
    public class RezerwacjaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezerwacjaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rezerwacja
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rezerwacjas.Include(r => r.Ksiazka);
            return View(await applicationDbContext.ToListAsync());
        }



        // GET: Rezerwacja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Rezerwacjas.FindAsync(id);
            if (rezerwacja == null)
            {
                return NotFound();
            }
            ViewData["KsiazkaID"] = new SelectList(_context.Ksiazkas, "KsiazkaID", "Nazwa", rezerwacja.KsiazkaID);
            return View(rezerwacja);
        }

        // POST: Rezerwacja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RezerwacjaID,DataRezerwacji,UserID,KsiazkaID")] Rezerwacja rezerwacja)
        {
            if (id != rezerwacja.RezerwacjaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezerwacja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezerwacjaExists(rezerwacja.RezerwacjaID))
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
            ViewData["KsiazkaID"] = new SelectList(_context.Ksiazkas, "KsiazkaID", "Nazwa", rezerwacja.KsiazkaID);
            return View(rezerwacja);
        }

        // GET: Rezerwacja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezerwacja = await _context.Rezerwacjas
                .Include(r => r.Ksiazka)
                .FirstOrDefaultAsync(m => m.RezerwacjaID == id);
            if (rezerwacja == null)
            {
                return NotFound();
            }

            return View(rezerwacja);
        }

        // POST: Rezerwacja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezerwacja = await _context.Rezerwacjas.FindAsync(id);
            _context.Rezerwacjas.Remove(rezerwacja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezerwacjaExists(int id)
        {
            return _context.Rezerwacjas.Any(e => e.RezerwacjaID == id);
        }
    }
}
