using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetHeritageGroupe8.Controllers
{
    public class afficheController : Controller
    {
        // GET: affiche
        public ActionResult Index()
        {
            return View();
        }

        // GET: affiche/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: affiche/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: affiche/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: affiche/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: affiche/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: affiche/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: affiche/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}