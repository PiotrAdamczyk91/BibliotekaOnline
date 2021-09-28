using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotekaOnline.Data;
using BibliotekaOnline.Models;
using System.Security.Claims;


namespace BibliotekaOnline.Controllers
{
    public class KsiazkaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KsiazkaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ksiazka
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ksiazkas.ToListAsync());
        }




        // GET: Ksiazka/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ksiazka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KsiazkaID,Nazwa,Autor,DataWydania,Opis")] Ksiazka ksiazka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ksiazka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ksiazka);
        }

        // GET: Ksiazka/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazkas.FindAsync(id);
            if (ksiazka == null)
            {
                return NotFound();
            }
            return View(ksiazka);
        }

        // POST: Ksiazka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KsiazkaID,Nazwa,Autor,DataWydania,Opis")] Ksiazka ksiazka)
        {
            if (id != ksiazka.KsiazkaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ksiazka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KsiazkaExists(ksiazka.KsiazkaID))
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
            return View(ksiazka);
        }

        // GET: Ksiazka/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ksiazka = await _context.Ksiazkas
                .FirstOrDefaultAsync(m => m.KsiazkaID == id);
            if (ksiazka == null)
            {
                return NotFound();
            }

            return View(ksiazka);
        }

        // POST: Ksiazka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ksiazka = await _context.Ksiazkas.FindAsync(id);
            _context.Ksiazkas.Remove(ksiazka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpPost, ActionName("Rezerwacja")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rezerwacja(int id)
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);

            Rezerwacja rezerwacja = new Rezerwacja
            {
                DataRezerwacji = DateTime.Now,
                KsiazkaID = id,
                UserID = userID,
            };
            _context.Add(rezerwacja);
            await _context.SaveChangesAsync();


            //return RedirectToAction("Index", "Ksiazka", new { test = userID });
            return RedirectToAction(nameof(Index));
        }


        [HttpPost, ActionName("ListaRezerwacji")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ListaRezerwacji(int id)
        {
            var ksiazka = await _context.Ksiazkas.FindAsync(id);
            //var user = await _context.Users.FindAsync(Rezerwacja);
            //ViewBag.NazwaKsiazki = ksiazka.Nazwa;

            //var rezerwacja
            var listaRezerwacji = await _context.Rezerwacjas.Where(a => a.KsiazkaID == id).ToListAsync();

            
            foreach(var item in listaRezerwacji)
            {
                //var obiektUser = _context.Users.Where(a => item.UserID == a.Id).ToString();

                var obiektUser = _context.Users.Where(a => a.Id == item.UserID).First().UserName;
                item.UserID = obiektUser.ToString();
            }

            return View(listaRezerwacji);
        }


        private bool KsiazkaExists(int id)
        {
            return _context.Ksiazkas.Any(e => e.KsiazkaID == id);
        }
    }
}
