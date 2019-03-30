using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetHeritageGroupe8.Data;
using ProjetHeritageGroupe8.Models;

namespace ProjetHeritageGroupe8.Controllers
{
    public class HeritiersController : Controller
    {
        private readonly HeritageDbContext _context;

        public HeritiersController(HeritageDbContext context)
        {
            _context = context;
        }

        // GET: Heritiers
        public async Task<IActionResult> Index()
        {
            return View(await _context.heritiers.ToListAsync());
        }

        // GET: Heritiers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heritier = await _context.heritiers
                .FirstOrDefaultAsync(m => m.HeritierID == id);
            if (heritier == null)
            {
                return NotFound();
            }

            return View(heritier);
        }

        // GET: Heritiers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Heritiers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HeritierID,description,code,illustration")] Heritier heritier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(heritier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(heritier);
        }

        // GET: Heritiers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heritier = await _context.heritiers.FindAsync(id);
            if (heritier == null)
            {
                return NotFound();
            }
            return View(heritier);
        }

        // POST: Heritiers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HeritierID,description,code,illustration")] Heritier heritier)
        {
            if (id != heritier.HeritierID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(heritier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeritierExists(heritier.HeritierID))
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
            return View(heritier);
        }

        // GET: Heritiers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heritier = await _context.heritiers
                .FirstOrDefaultAsync(m => m.HeritierID == id);
            if (heritier == null)
            {
                return NotFound();
            }

            return View(heritier);
        }

        // POST: Heritiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var heritier = await _context.heritiers.FindAsync(id);
            _context.heritiers.Remove(heritier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeritierExists(int id)
        {
            return _context.heritiers.Any(e => e.HeritierID == id);
        }
    }
}
