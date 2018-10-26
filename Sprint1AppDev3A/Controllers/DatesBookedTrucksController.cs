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
    public class DatesBookedTrucksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DatesBookedTrucks
        public ActionResult Index()
        {
            var datesBookedTrucks = db.DatesBookedTrucks.Include(d => d.TruckID);
            return View(datesBookedTrucks.ToList());
        }

        // GET: DatesBookedTrucks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatesBookedTrucks datesBookedTrucks = db.DatesBookedTrucks.Find(id);
            if (datesBookedTrucks == null)
            {
                return HttpNotFound();
            }
            return View(datesBookedTrucks);
        }

        // GET: DatesBookedTrucks/Create
        public ActionResult Create()
        {
            ViewBag.TruckID = new SelectList(db.NewTrucks, "TruckId", "make");
            return View();
        }

        // POST: DatesBookedTrucks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrucKey,TruckID,PickUpDate,DropOffDate")] DatesBookedTrucks datesBookedTrucks)
        {
            if (ModelState.IsValid)
            {
                db.DatesBookedTrucks.Add(datesBookedTrucks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TruckID = new SelectList(db.NewTrucks, "TruckId", "make", datesBookedTrucks.TruckID);
            return View(datesBookedTrucks);
        }

        // GET: DatesBookedTrucks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatesBookedTrucks datesBookedTrucks = db.DatesBookedTrucks.Find(id);
            if (datesBookedTrucks == null)
            {
                return HttpNotFound();
            }
            ViewBag.TruckID = new SelectList(db.NewTrucks, "TruckId", "make", datesBookedTrucks.TruckID);
            return View(datesBookedTrucks);
        }

        // POST: DatesBookedTrucks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrucKey,TruckID,PickUpDate,DropOffDate")] DatesBookedTrucks datesBookedTrucks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datesBookedTrucks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TruckID = new SelectList(db.NewTrucks, "TruckId", "make", datesBookedTrucks.TruckID);
            return View(datesBookedTrucks);
        }

        // GET: DatesBookedTrucks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatesBookedTrucks datesBookedTrucks = db.DatesBookedTrucks.Find(id);
            if (datesBookedTrucks == null)
            {
                return HttpNotFound();
            }
            return View(datesBookedTrucks);
        }

        // POST: DatesBookedTrucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatesBookedTrucks datesBookedTrucks = db.DatesBookedTrucks.Find(id);
            db.DatesBookedTrucks.Remove(datesBookedTrucks);
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
