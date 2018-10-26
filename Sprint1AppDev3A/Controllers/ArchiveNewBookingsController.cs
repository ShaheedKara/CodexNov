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
    public class ArchiveNewBookingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ArchiveNewBookings
        public ActionResult Index()
        {
            return View(db.ArchiveNewBookings.ToList());
        }

        // GET: ArchiveNewBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArchiveNewBooking archiveNewBooking = db.ArchiveNewBookings.Find(id);
            if (archiveNewBooking == null)
            {
                return HttpNotFound();
            }
            return View(archiveNewBooking);
        }

        // GET: ArchiveNewBookings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArchiveNewBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingIds,pickupdate,clientname,cellnum,email,ConNum,ConType,Size,specInstruct,testtext,two,Distance,final,Collection,Dropoff,priorty,est,estTime,news,newss,Booked,vat")] ArchiveNewBooking archiveNewBooking)
        {
            if (ModelState.IsValid)
            {
                db.ArchiveNewBookings.Add(archiveNewBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(archiveNewBooking);
        }

        // GET: ArchiveNewBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArchiveNewBooking archiveNewBooking = db.ArchiveNewBookings.Find(id);
            if (archiveNewBooking == null)
            {
                return HttpNotFound();
            }
            return View(archiveNewBooking);
        }

        // POST: ArchiveNewBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingIds,pickupdate,clientname,cellnum,email,ConNum,ConType,Size,specInstruct,testtext,two,Distance,final,Collection,Dropoff,priorty,est,estTime,news,newss,Booked,vat")] ArchiveNewBooking archiveNewBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(archiveNewBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(archiveNewBooking);
        }

        // GET: ArchiveNewBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArchiveNewBooking archiveNewBooking = db.ArchiveNewBookings.Find(id);
            if (archiveNewBooking == null)
            {
                return HttpNotFound();
            }
            return View(archiveNewBooking);
        }

        // POST: ArchiveNewBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArchiveNewBooking archiveNewBooking = db.ArchiveNewBookings.Find(id);
            db.ArchiveNewBookings.Remove(archiveNewBooking);
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
