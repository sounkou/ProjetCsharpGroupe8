using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetHeritageGroupe8.Data;
using ProjetHeritageGroupe8.Models;

namespace ProjetHeritageGroupe8.Controllers
{
    public class AyantDroitsController : Controller
    {
        private readonly HeritageDbContext _context;
        private readonly IHostingEnvironment he;

        public AyantDroitsController(HeritageDbContext context, IHostingEnvironment e)
        {
            _context = context;
            he = e;
        }

        // GET: AyantDroits
        public async Task<IActionResult> Index()
        {
            var heritageDbContext = _context.AyantDroit.Include(a => a.typeHeritier);
            return View(await heritageDbContext.ToListAsync());
        }

        // GET: AyantDroits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ayantDroit = await _context.AyantDroit
                .Include(a => a.typeHeritier)
                .FirstOrDefaultAsync(m => m.AyantDroitID == id);
            if (ayantDroit == null)
            {
                return NotFound();
            }

            return View(ayantDroit);
        }

        // GET: AyantDroits/Create
        public IActionResult Create()
        {
            ViewData["illustration"] = new SelectList(_context.heritiers, "illustration", "illustration");
            return View();
        }

        

        // POST: AyantDroits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AyantDroitID,nom,prenom,sexe,dateNaissance,designation,ImageADr,description,DateCreation,HeritierID")] AyantDroit ayantDroit)
        {          

            if (ModelState.IsValid)
            {
                _context.Add(ayantDroit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["illustration"] = new SelectList(_context.heritiers, "illustration", "illustration", ayantDroit.typeHeritier.illustration);
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
            ViewData["HeritierID"] = new SelectList(_context.heritiers, "HeritierID", "HeritierID", ayantDroit.HeritierID);
            return View(ayantDroit);
        }

        // POST: AyantDroits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AyantDroitID,nom,prenom,sexe,dateNaissance,designation,ImageADr,description,DateCreation,HeritierID")] AyantDroit ayantDroit)
        {
            if (id != ayantDroit.AyantDroitID)
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
                    if (!AyantDroitExists(ayantDroit.AyantDroitID))
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
            ViewData["HeritierID"] = new SelectList(_context.heritiers, "HeritierID", "HeritierID", ayantDroit.HeritierID);
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
                .Include(a => a.typeHeritier)
                .FirstOrDefaultAsync(m => m.AyantDroitID == id);
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
            return _context.AyantDroit.Any(e => e.AyantDroitID == id);
        }
    }
}
