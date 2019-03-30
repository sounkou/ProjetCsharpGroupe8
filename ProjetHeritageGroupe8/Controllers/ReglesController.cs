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
    public class ReglesController : Controller
    {
        private readonly HeritageDbContext _context;

        public ReglesController(HeritageDbContext context)
        {
            _context = context;
        }

        // GET: Regles
        public async Task<IActionResult> Index()
        {
            return View(await _context.regles.ToListAsync());
        }

        // GET: Regles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regle = await _context.regles
                .FirstOrDefaultAsync(m => m.RegleID == id);
            if (regle == null)
            {
                return NotFound();
            }

            return View(regle);
        }

        // GET: Regles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegleID,description,commentaire")] Regle regle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regle);
        }

        // GET: Regles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regle = await _context.regles.FindAsync(id);
            if (regle == null)
            {
                return NotFound();
            }
            return View(regle);
        }

        // POST: Regles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegleID,description,commentaire")] Regle regle)
        {
            if (id != regle.RegleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegleExists(regle.RegleID))
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
            return View(regle);
        }

        // GET: Regles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regle = await _context.regles
                .FirstOrDefaultAsync(m => m.RegleID == id);
            if (regle == null)
            {
                return NotFound();
            }

            return View(regle);
        }

        // POST: Regles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regle = await _context.regles.FindAsync(id);
            _context.regles.Remove(regle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegleExists(int id)
        {
            return _context.regles.Any(e => e.RegleID == id);
        }
    }
}
