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
    public class VatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vats
        public ActionResult Index()
        {
            return View(db.Vats.ToList());
        }

        // GET: Vats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vat vat = db.Vats.Find(id);
            if (vat == null)
            {
                return HttpNotFound();
            }
            return View(vat);
        }

        // GET: Vats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,exempt,standardRated,zeroRated")] Vat vat)
        {
            if (ModelState.IsValid)
            {
                db.Vats.Add(vat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vat);
        }

        // GET: Vats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vat vat = db.Vats.Find(id);
            if (vat == null)
            {
                return HttpNotFound();
            }
            return View(vat);
        }

        // POST: Vats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,exempt,standardRated,zeroRated")] Vat vat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vat);
        }

        // GET: Vats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vat vat = db.Vats.Find(id);
            if (vat == null)
            {
                return HttpNotFound();
            }
            return View(vat);
        }

        // POST: Vats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vat vat = db.Vats.Find(id);
            db.Vats.Remove(vat);
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
