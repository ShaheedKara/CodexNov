using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sprint1AppDev3A.Models;

namespace Sprint1AppDev3A.Controllers
{
    public class TrailerMk2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TrailerMk2
        public ActionResult Index()
        {
            return View(db.TrailerMk2.ToList());
        }

        // GET: TrailerMk2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrailerMk2 trailerMk2 = db.TrailerMk2.Find(id);
            if (trailerMk2 == null)
            {
                return HttpNotFound();
            }
            return View(trailerMk2);
        }

        // GET: TrailerMk2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrailerMk2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrailerId,reg,TrailerSize,Location,exp")] TrailerMk2 trailerMk2)
        {
            if (ModelState.IsValid)
            {
                db.TrailerMk2.Add(trailerMk2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trailerMk2);
        }

        // GET: TrailerMk2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrailerMk2 trailerMk2 = db.TrailerMk2.Find(id);
            if (trailerMk2 == null)
            {
                return HttpNotFound();
            }
            return View(trailerMk2);
        }

        // POST: TrailerMk2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrailerId,reg,TrailerSize,Location,exp")] TrailerMk2 trailerMk2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trailerMk2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trailerMk2);
        }

        // GET: TrailerMk2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrailerMk2 trailerMk2 = db.TrailerMk2.Find(id);
            if (trailerMk2 == null)
            {
                return HttpNotFound();
            }
            return View(trailerMk2);
        }

        // POST: TrailerMk2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrailerMk2 trailerMk2 = db.TrailerMk2.Find(id);
            db.TrailerMk2.Remove(trailerMk2);
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
