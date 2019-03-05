using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HeritageApp.Models;
using HeritageApp.Models.Entities;

namespace HeritageApp.Controllers
{
    public class AyantDroitsController : Controller
    {
        private readonly HeritageAppContext _context;

        public AyantDroitsController(HeritageAppContext context)
        {
            _context = context;
        }

        // GET: AyantDroits
        public async Task<IActionResult> Index()
        {
            return View(await _context.AyantDroit.ToListAsync());
        }

        // GET: AyantDroits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ayantDroit = await _context.AyantDroit
                .FirstOrDefaultAsync(m => m.ayantDroitID == id);
            if (ayantDroit == null)
            {
                return NotFound();
            }

            return View(ayantDroit);
        }

        // GET: AyantDroits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AyantDroits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ayantDroitID,Designation,Description")] AyantDroit ayantDroit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ayantDroit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ayantDroit);
        }

        // GET: AyantDroits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ayantDroit = await _context.AyantDroit.FindAsync(id);
            if (ayantDroit == null)
            {
                return NotFound();
            }
            return View(ayantDroit);
        }

        // POST: AyantDroits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ayantDroitID,Designation,Description")] AyantDroit ayantDroit)
        {
            if (id != ayantDroit.ayantDroitID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ayantDroit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AyantDroitExists(ayantDroit.ayantDroitID))
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
            return View(ayantDroit);
        }

        // GET: AyantDroits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ayantDroit = await _context.AyantDroit
                .FirstOrDefaultAsync(m => m.ayantDroitID == id);
            if (ayantDroit == null)
            {
                return NotFound();
            }

            return View(ayantDroit);
        }

        // POST: AyantDroits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ayantDroit = await _context.AyantDroit.FindAsync(id);
            _context.AyantDroit.Remove(ayantDroit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AyantDroitExists(int id)
        {
            return _context.AyantDroit.Any(e => e.ayantDroitID == id);
        }
    }
}
