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
    public class PreSchedulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: PreSchedules
        public ActionResult Index()
        {
            var preSchedules = db.PreSchedules.Include(p => p.Resources);
            foreach (var pre in preSchedules.ToList())
            {
                ArchiveBooking Archive = new ArchiveBooking();
                if (pre.end <= DateTime.Now)
                {
                    var Find = db.PreSchedules.Find(pre.PreId);
                    //Add it to the new class 
                    Archive.PreId = Find.PreId;
                    Archive.RefNum = Find.RefNum;
                    Archive.ContainerSize = Find.ContainerSize;
                    Archive.pickupLocation = Find.pickupLocation;
                    Archive.dropoffLocation = Find.dropoffLocation;
                    Archive.transportType = Find.transportType;
                    Archive.start = Find.start;
                    Archive.end = Find.end;
                    Archive.transit = Find.transit;
                    Archive.Booked = Find.Booked;
                    Archive.id = Find.id;
                    db.ArchiveBookings.Add(Archive);
                    db.SaveChanges();
                    //Deletes The Selected Records
                    db.PreSchedules.Remove(Find);
                    db.SaveChanges();
                }

            }
            return View(preSchedules.ToList());
        }

        // GET: PreSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreSchedule preSchedule = db.PreSchedules.Find(id);
            if (preSchedule == null)
            {
                return HttpNotFound();
            }
            return View(preSchedule);
        }

        // GET: PreSchedules/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.Resources, "id", "statusResource");
            return View();
        }

        // POST: PreSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PreId,RefNum,ContainerSize,pickupLocation,dropoffLocation,transportType,start,end,transit,Booked,id")] PreSchedule preSchedule)
        {
            if (ModelState.IsValid)
            {
                
                db.PreSchedules.Add(preSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.Resources, "id", "statusResource", preSchedule.id);
            return View(preSchedule);
        }

        // GET: PreSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreSchedule preSchedule = db.PreSchedules.Find(id);
            if (preSchedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.Resources, "id", "statusResource", preSchedule.id);
            return View(preSchedule);
        }

        // POST: PreSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PreId,RefNum,ContainerSize,pickupLocation,dropoffLocation,transportType,start,end,transit,Booked,id")] PreSchedule preSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.Resources, "id", "statusResource", preSchedule.id);
            return View(preSchedule);
        }

        // GET: PreSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreSchedule preSchedule = db.PreSchedules.Find(id);
            if (preSchedule == null)
            {
                return HttpNotFound();
            }
            return View(preSchedule);
        }

        // POST: PreSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PreSchedule preSchedule = db.PreSchedules.Find(id);
            db.PreSchedules.Remove(preSchedule);
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
