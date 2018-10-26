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
    public class DatesBookedTrailersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DatesBookedTrailers
        public ActionResult Index()
        {
            var datesBookedTrailers = db.DatesBookedTrailers.Include(d => d.TrailID);
            return View(datesBookedTrailers.ToList());
        }

        // GET: DatesBookedTrailers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatesBookedTrailer datesBookedTrailer = db.DatesBookedTrailers.Find(id);
            if (datesBookedTrailer == null)
            {
                return HttpNotFound();
            }
            return View(datesBookedTrailer);
        }

        // GET: DatesBookedTrailers/Create
        public ActionResult Create()
        {
            ViewBag.TrailID = new SelectList(db.NewTrailers, "TrailerId", "reg");
            return View();
        }

        // POST: DatesBookedTrailers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TraiKey,TrailID,PickUpDate,DropOffDate")] DatesBookedTrailer datesBookedTrailer)
        {
            if (ModelState.IsValid)
            {
                db.DatesBookedTrailers.Add(datesBookedTrailer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrailID = new SelectList(db.NewTrailers, "TrailerId", "reg", datesBookedTrailer.TrailID);
            return View(datesBookedTrailer);
        }

        // GET: DatesBookedTrailers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatesBookedTrailer datesBookedTrailer = db.DatesBookedTrailers.Find(id);
            if (datesBookedTrailer == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrailID = new SelectList(db.NewTrailers, "TrailerId", "reg", datesBookedTrailer.TrailID);
            return View(datesBookedTrailer);
        }

        // POST: DatesBookedTrailers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TraiKey,TrailID,PickUpDate,DropOffDate")] DatesBookedTrailer datesBookedTrailer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datesBookedTrailer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrailID = new SelectList(db.NewTrailers, "TrailerId", "reg", datesBookedTrailer.TrailID);
            return View(datesBookedTrailer);
        }

        // GET: DatesBookedTrailers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatesBookedTrailer datesBookedTrailer = db.DatesBookedTrailers.Find(id);
            if (datesBookedTrailer == null)
            {
                return HttpNotFound();
            }
            return View(datesBookedTrailer);
        }

        // POST: DatesBookedTrailers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatesBookedTrailer datesBookedTrailer = db.DatesBookedTrailers.Find(id);
            db.DatesBookedTrailers.Remove(datesBookedTrailer);
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
