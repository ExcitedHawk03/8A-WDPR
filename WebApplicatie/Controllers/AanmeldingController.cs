using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebApplicatie.Controllers
{
    public class AanmeldingController : Controller
    {
        private readonly ClientContext _context;

        public AanmeldingController(ClientContext context)
        {
            _context = context;
        }

        public IQueryable<Aanmelding> Zoek (IQueryable<Aanmelding> lijst, string filter)
        {
            if (filter == null)
            {
                return lijst;
            }
            else {
            return lijst.Where(a => a.Hulpverlener.ToLower().Contains(filter.ToLower()));
            }
        }

        // GET: Aanmelding
        public async Task<IActionResult> Index(string filter)
        {
            ViewData["Filter"] = filter;

            return View(await Zoek(_context.Aanmelding, filter).ToListAsync());
        }

        // GET: Aanmelding/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aanmelding = await _context.Aanmelding
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aanmelding == null)
            {
                return NotFound();
            }

            return View(aanmelding);
        }

        // GET: Aanmelding/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aanmelding/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VoorNaam,AchterNaam,Datum,Hulpverlener")] Aanmelding aanmelding)
        {

            if (ModelState.IsValid)
            {
                _context.Add(aanmelding);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Gelukt),
                        "Aanmelding");
            }
            return View(aanmelding);
        }

        // GET: Aanmelding/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aanmelding = await _context.Aanmelding.FindAsync(id);
            if (aanmelding == null)
            {
                return NotFound();
            }
            return View(aanmelding);
        }

        // POST: Aanmelding/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VoorNaam,AchterNaam,Datum,Hulpverlener")] Aanmelding aanmelding)
        {
            if (id != aanmelding.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aanmelding);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AanmeldingExists(aanmelding.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                 return RedirectToAction(nameof(Aanpassen),
                        "Aanmelding");
            }
            return View(aanmelding);
        }

        // GET: Aanmelding/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aanmelding = await _context.Aanmelding
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aanmelding == null)
            {
                return NotFound();
            }

            return View(aanmelding);
        }

        // POST: Aanmelding/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aanmelding = await _context.Aanmelding.FindAsync(id);
            _context.Aanmelding.Remove(aanmelding);
            await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Aanpassen),
                        "Afkeuren");
        }

        private bool AanmeldingExists(int id)
        {
            return _context.Aanmelding.Any(e => e.Id == id);
        }

        public IActionResult Gelukt () 
        {
            return View();
        }

         public IActionResult Afkeuren () 
        {
            return View();
        }

        public IActionResult Aanpassen ()
        {
            return View ();
        }
    }
}
