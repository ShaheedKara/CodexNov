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
    public class ArchiveBookingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ArchiveBookings
        public ActionResult Index()
        {
            return View(db.ArchiveBookings.ToList());
        }

        // GET: ArchiveBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArchiveBooking archiveBooking = db.ArchiveBookings.Find(id);
            if (archiveBooking == null)
            {
                return HttpNotFound();
            }
            return View(archiveBooking);
        }

        // GET: ArchiveBookings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArchiveBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PreId,RefNum,ContainerSize,pickupLocation,dropoffLocation,transportType,start,end,transit,Booked,id")] ArchiveBooking archiveBooking)
        {
            if (ModelState.IsValid)
            {
                db.ArchiveBookings.Add(archiveBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(archiveBooking);
        }

        // GET: ArchiveBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArchiveBooking archiveBooking = db.ArchiveBookings.Find(id);
            if (archiveBooking == null)
            {
                return HttpNotFound();
            }
            return View(archiveBooking);
        }

        // POST: ArchiveBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PreId,RefNum,ContainerSize,pickupLocation,dropoffLocation,transportType,start,end,transit,Booked,id")] ArchiveBooking archiveBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(archiveBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(archiveBooking);
        }

        // GET: ArchiveBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArchiveBooking archiveBooking = db.ArchiveBookings.Find(id);
            if (archiveBooking == null)
            {
                return HttpNotFound();
            }
            return View(archiveBooking);
        }

        // POST: ArchiveBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArchiveBooking archiveBooking = db.ArchiveBookings.Find(id);
            db.ArchiveBookings.Remove(archiveBooking);
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
