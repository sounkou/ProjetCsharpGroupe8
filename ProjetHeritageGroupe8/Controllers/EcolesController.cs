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
    public class EcolesController : Controller
    {
        private readonly HeritageDbContext _context;

        public EcolesController(HeritageDbContext context)
        {
            _context = context;
        }

        // GET: Ecoles
        public async Task<IActionResult> Index()
        {
            var heritageDbContext = _context.Ecole.Include(e => e.Regles);
            return View(await heritageDbContext.ToListAsync());
        }

        // GET: Ecoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ecole = await _context.Ecole
                .Include(e => e.Regles)
                .FirstOrDefaultAsync(m => m.EcoleID == id);
            if (ecole == null)
            {
                return NotFound();
            }

            return View(ecole);
        }

        // GET: Ecoles/Create
        public IActionResult Create()
        {
            ViewData["RegleID"] = new SelectList(_context.regles, "RegleID", "RegleID");
            return View();
        }

        // POST: Ecoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EcoleID,nom,description,RegleID")] Ecole ecole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ecole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegleID"] = new SelectList(_context.regles, "RegleID", "RegleID", ecole.RegleID);
            return View(ecole);
        }

        // GET: Ecoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ecole = await _context.Ecole.FindAsync(id);
            if (ecole == null)
            {
                return NotFound();
            }
            ViewData["RegleID"] = new SelectList(_context.regles, "RegleID", "RegleID", ecole.RegleID);
            return View(ecole);
        }

        // POST: Ecoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EcoleID,nom,description,RegleID")] Ecole ecole)
        {
            if (id != ecole.EcoleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ecole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EcoleExists(ecole.EcoleID))
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
            ViewData["RegleID"] = new SelectList(_context.regles, "RegleID", "RegleID", ecole.RegleID);
            return View(ecole);
        }

        // GET: Ecoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ecole = await _context.Ecole
                .Include(e => e.Regles)
                .FirstOrDefaultAsync(m => m.EcoleID == id);
            if (ecole == null)
            {
                return NotFound();
            }

            return View(ecole);
        }

        // POST: Ecoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ecole = await _context.Ecole.FindAsync(id);
            _context.Ecole.Remove(ecole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EcoleExists(int id)
        {
            return _context.Ecole.Any(e => e.EcoleID == id);
        }
    }
}
