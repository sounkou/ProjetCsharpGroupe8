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
    public class BiensController : Controller
    {
        private readonly HeritageDbContext _context;

        public BiensController(HeritageDbContext context)
        {
            _context = context;
        }

        // GET: Biens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Biens.ToListAsync());
        }

        // GET: Biens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biens = await _context.Biens
                .FirstOrDefaultAsync(m => m.BiensID == id);
            if (biens == null)
            {
                return NotFound();
            }

            return View(biens);
        }

        // GET: Biens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Biens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BiensID,description")] Biens biens)
        {
            if (ModelState.IsValid)
            {
                _context.Add(biens);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(biens);
        }

        // GET: Biens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biens = await _context.Biens.FindAsync(id);
            if (biens == null)
            {
                return NotFound();
            }
            return View(biens);
        }

        // POST: Biens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BiensID,description")] Biens biens)
        {
            if (id != biens.BiensID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biens);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiensExists(biens.BiensID))
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
            return View(biens);
        }

        // GET: Biens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var biens = await _context.Biens
                .FirstOrDefaultAsync(m => m.BiensID == id);
            if (biens == null)
            {
                return NotFound();
            }

            return View(biens);
        }

        // POST: Biens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var biens = await _context.Biens.FindAsync(id);
            _context.Biens.Remove(biens);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiensExists(int id)
        {
            return _context.Biens.Any(e => e.BiensID == id);
        }
    }
}
