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
    public class HeritagesController : Controller
    {
        private readonly HeritageDbContext _context;

        public HeritagesController(HeritageDbContext context)
        {
            _context = context;
        }

        // GET: Heritages
        public async Task<IActionResult> Index()
        {
            var heritageDbContext = _context.heritages.Include(h => h.Biens).Include(h => h.Ecole);
            return View(await heritageDbContext.ToListAsync());
        }

        // GET: Heritages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heritage = await _context.heritages
                .Include(h => h.Biens)
                .Include(h => h.Ecole)
                .FirstOrDefaultAsync(m => m.HeritageID == id);
            if (heritage == null)
            {
                return NotFound();
            }

            return View(heritage);
        }

        // GET: Heritages/Create
        public IActionResult Create()
        {
            ViewData["BiensID"] = new SelectList(_context.Biens, "BiensID", "BiensID");
            ViewData["EcoleID"] = new SelectList(_context.Ecole, "EcoleID", "EcoleID");
            return View();
        }

        // POST: Heritages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HeritageID,description,DateDeces,DateHeritage,EcoleID,montant,BiensID")] Heritage heritage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(heritage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BiensID"] = new SelectList(_context.Biens, "BiensID", "BiensID", heritage.BiensID);
            ViewData["EcoleID"] = new SelectList(_context.Ecole, "EcoleID", "EcoleID", heritage.EcoleID);
            return View(heritage);
        }

        // GET: Heritages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heritage = await _context.heritages.FindAsync(id);
            if (heritage == null)
            {
                return NotFound();
            }
            ViewData["BiensID"] = new SelectList(_context.Biens, "BiensID", "BiensID", heritage.BiensID);
            ViewData["EcoleID"] = new SelectList(_context.Ecole, "EcoleID", "EcoleID", heritage.EcoleID);
            return View(heritage);
        }

        // POST: Heritages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HeritageID,description,DateDeces,DateHeritage,EcoleID,montant,BiensID")] Heritage heritage)
        {
            if (id != heritage.HeritageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(heritage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeritageExists(heritage.HeritageID))
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
            ViewData["BiensID"] = new SelectList(_context.Biens, "BiensID", "BiensID", heritage.BiensID);
            ViewData["EcoleID"] = new SelectList(_context.Ecole, "EcoleID", "EcoleID", heritage.EcoleID);
            return View(heritage);
        }

        // GET: Heritages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heritage = await _context.heritages
                .Include(h => h.Biens)
                .Include(h => h.Ecole)
                .FirstOrDefaultAsync(m => m.HeritageID == id);
            if (heritage == null)
            {
                return NotFound();
            }

            return View(heritage);
        }

        // POST: Heritages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var heritage = await _context.heritages.FindAsync(id);
            _context.heritages.Remove(heritage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeritageExists(int id)
        {
            return _context.heritages.Any(e => e.HeritageID == id);
        }
    }
}
