using RecommandationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;

namespace RecommandationApp.Controllers
{
    public class RepresentantController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Representant
        public ActionResult Index(string searchString)
        {
            var representants = from m in db.Representants
                               select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                representants = representants.Where(s => s.entreprise.Contains(searchString));
            }

            return View(representants);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Representant representant = db.Representants.Find(id);
            if (representant == null)
            {
                return HttpNotFound();
            }
            return View(representant);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,nom, prenom, entreprise,adresse")] Representant representant )
        {
            if (ModelState.IsValid)
            {
                db.Representants.Add(representant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(representant);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Representant representant = db.Representants.Find(id);
            if (representant == null)
            {
                return HttpNotFound();
            }
            return View(representant);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,nom, prenom, entreprise,adresse")] Representant representant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(representant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(representant);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Representant representant = db.Representants.Find(id);
            if (representant == null)
            {
                return HttpNotFound();
            }
            return View(representant);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Representant representant = db.Representants.Find(id);
            db.Representants.Remove(representant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }

}
