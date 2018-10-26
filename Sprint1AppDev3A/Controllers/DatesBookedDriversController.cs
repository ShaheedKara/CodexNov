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
    public class DatesBookedDriversController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DatesBookedDrivers
        public ActionResult Index()
        {
            var datesBookedDrivers = db.DatesBookedDrivers.Include(d => d.NewDrivers);
            return View(datesBookedDrivers.ToList());
        }

        // GET: DatesBookedDrivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatesBookedDriver datesBookedDriver = db.DatesBookedDrivers.Find(id);
            if (datesBookedDriver == null)
            {
                return HttpNotFound();
            }
            return View(datesBookedDriver);
        }

        // GET: DatesBookedDrivers/Create
        public ActionResult Create()
        {
            ViewBag.DriveID = new SelectList(db.NewDrivers, "DriverId", "Id");
            return View();
        }

        // POST: DatesBookedDrivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriKey,DriveID,PickUpDate,DropOffDate")] DatesBookedDriver datesBookedDriver)
        {
            if (ModelState.IsValid)
            {
                db.DatesBookedDrivers.Add(datesBookedDriver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DriveID = new SelectList(db.NewDrivers, "DriverId", "Id", datesBookedDriver.DriveID);
            return View(datesBookedDriver);
        }

        // GET: DatesBookedDrivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatesBookedDriver datesBookedDriver = db.DatesBookedDrivers.Find(id);
            if (datesBookedDriver == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriveID = new SelectList(db.NewDrivers, "DriverId", "Id", datesBookedDriver.DriveID);
            return View(datesBookedDriver);
        }

        // POST: DatesBookedDrivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriKey,DriveID,PickUpDate,DropOffDate")] DatesBookedDriver datesBookedDriver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datesBookedDriver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DriveID = new SelectList(db.NewDrivers, "DriverId", "Id", datesBookedDriver.DriveID);
            return View(datesBookedDriver);
        }

        // GET: DatesBookedDrivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatesBookedDriver datesBookedDriver = db.DatesBookedDrivers.Find(id);
            if (datesBookedDriver == null)
            {
                return HttpNotFound();
            }
            return View(datesBookedDriver);
        }

        // POST: DatesBookedDrivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatesBookedDriver datesBookedDriver = db.DatesBookedDrivers.Find(id);
            db.DatesBookedDrivers.Remove(datesBookedDriver);
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
