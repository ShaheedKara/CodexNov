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
    public class CalAmtsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CalAmts
        public ActionResult Index()
        {
            return View(db.CalAmts.ToList());
        }

        // GET: CalAmts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalAmt calAmt = db.CalAmts.Find(id);
            if (calAmt == null)
            {
                return HttpNotFound();
            }
            return View(calAmt);
        }

        // GET: CalAmts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalAmts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,fuel,Rate")] CalAmt calAmt)
        {
            if (ModelState.IsValid)
            {
                db.CalAmts.Add(calAmt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calAmt);
        }

        // GET: CalAmts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalAmt calAmt = db.CalAmts.Find(id);
            if (calAmt == null)
            {
                return HttpNotFound();
            }
            return View(calAmt);
        }

        // POST: CalAmts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fuel,Rate")] CalAmt calAmt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calAmt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calAmt);
        }

        // GET: CalAmts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalAmt calAmt = db.CalAmts.Find(id);
            if (calAmt == null)
            {
                return HttpNotFound();
            }
            return View(calAmt);
        }

        // POST: CalAmts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CalAmt calAmt = db.CalAmts.Find(id);
            db.CalAmts.Remove(calAmt);
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
