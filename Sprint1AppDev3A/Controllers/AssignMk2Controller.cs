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
    public class AssignMk2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AssignMk2
        public ActionResult Index()
        {
            var assignMk2 = db.AssignMk2.Include(a => a.NewBookings).Include(a => a.NewDrivers).Include(a => a.NewTrailers).Include(a => a.NewTruck);
            return View(assignMk2.ToList());
        }

        // GET: AssignMk2/Details/5
        public ActionResult Details(int? id)
        {
            var assign = db.AssignMk2.Find(id);
            var booking = db.NewBookings.Find(assign.BookingIds);
            DeliveryNote dnote = new DeliveryNote();

            dnote.clientname = booking.clientname;
            dnote.ConType = booking.ConType;
            dnote.specInstruct = booking.specInstruct;
            dnote.Size = booking.Size;
            dnote.Dropoff = booking.Dropoff;
            dnote.dateCreated = System.DateTime.Now;

            db.DeliveryNotes.Add(dnote);
            db.SaveChanges();


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignMk2 assignMk2 = db.AssignMk2.Find(id);
            if (assignMk2 == null)
            {
                return HttpNotFound();
            }
            return View(assignMk2);
        }

        // GET: AssignMk2/Create
        public ActionResult Create()
        {
            ViewBag.BookingIds = new SelectList(db.NewBookings, "BookingIds", "ConNum");
            ViewBag.DriverId = new SelectList(db.NewDrivers, "DriverId", "Email");
            ViewBag.TrailerId = new SelectList(db.NewTrailers, "TrailerId", "reg");
            ViewBag.TruckId = new SelectList(db.NewTrucks.Where(x=>x.Capacity<18), "TruckId", "reg");
            return View();
        }

        // POST: AssignMk2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TruckId,DriverId,TrailerId,BookingIds")] AssignMk2 assignMk2 ,int? id)
        {
            if (ModelState.IsValid)
            {
                //var Bid = assignMk2.NewBookings;
                //var Bid = db.NewBookings.Find(assignMk2.NewBookings.BookingIds);
                
                var Size = db.NewBookings.Find(assignMk2.BookingIds).Size;
                double conSize = Convert.ToDouble(Size.Replace("m","").Trim());
                var TruckCap = db.NewTrucks.Find(assignMk2.TruckId);
                if (TruckCap.Capacity<=18)
                {
                    if (conSize == 6)
                    {
                        TruckCap.Capacity = TruckCap.Capacity + 6;
                    }
                    else if (conSize == 12)
                    {
                        TruckCap.Capacity = TruckCap.Capacity + 12;
                    }

                }
                if (TruckCap.Capacity == 18)
                {
                    TruckCap.Status = "In Use";//Better Status For this
                }
                //needs to take out booked record...
                var Booked = db.NewBookings.Find(assignMk2.BookingIds).Booked==true;
                //Creates...
                db.AssignMk2.Add(assignMk2);
                db.SaveChanges();
                return RedirectToAction("RenderView");
            }

            ViewBag.BookingIds = new SelectList(db.NewBookings, "BookingIds", "clientname", assignMk2.BookingIds);
            ViewBag.DriverId = new SelectList(db.NewDrivers, "DriverId", "Id", assignMk2.DriverId);
            ViewBag.TrailerId = new SelectList(db.NewTrailers, "TrailerId", "reg", assignMk2.TrailerId);
            ViewBag.TruckId = new SelectList(db.NewTrucks, "TruckId", "make", assignMk2.TruckId);
            return View(assignMk2);
        }

        // GET: AssignMk2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignMk2 assignMk2 = db.AssignMk2.Find(id);
            if (assignMk2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingIds = new SelectList(db.NewBookings, "BookingIds", "clientname", assignMk2.BookingIds);
            ViewBag.DriverId = new SelectList(db.NewDrivers, "DriverId", "Id", assignMk2.DriverId);
            ViewBag.TrailerId = new SelectList(db.NewTrailers, "TrailerId", "reg", assignMk2.TrailerId);
            ViewBag.TruckId = new SelectList(db.NewTrucks, "TruckId", "make", assignMk2.TruckId);
            return View(assignMk2);
        }

        // POST: AssignMk2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TruckId,DriverId,TrailerId,BookingIds")] AssignMk2 assignMk2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignMk2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingIds = new SelectList(db.NewBookings, "BookingIds", "clientname", assignMk2.BookingIds);
            ViewBag.DriverId = new SelectList(db.NewDrivers, "DriverId", "Id", assignMk2.DriverId);
            ViewBag.TrailerId = new SelectList(db.NewTrailers, "TrailerId", "reg", assignMk2.TrailerId);
            ViewBag.TruckId = new SelectList(db.NewTrucks, "TruckId", "make", assignMk2.TruckId);
            return View(assignMk2);
        }

        // GET: AssignMk2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignMk2 assignMk2 = db.AssignMk2.Find(id);
            if (assignMk2 == null)
            {
                return HttpNotFound();
            }
            return View(assignMk2);
        }

        // POST: AssignMk2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignMk2 assignMk2 = db.AssignMk2.Find(id);
            db.AssignMk2.Remove(assignMk2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RenderView()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult BookingIndex()
        {
            ArchiveNewBooking Archive = new ArchiveNewBooking();
            foreach (var item in db.NewBookings.ToList())
            {
                if (item.pickupdate<=DateTime.Now)
                {
                    Archive.Booked = item.Booked;
                    Archive.BookingIds = item.BookingIds;
                    Archive.cellnum = item.cellnum;
                    Archive.clientname = item.clientname;
                    Archive.Collection = item.Collection;
                    Archive.ConNum = item.ConNum;
                    Archive.ConType = item.ConType;
                    Archive.Distance = item.Distance;
                    Archive.Dropoff = item.Dropoff;
                    Archive.email = item.email;
                    Archive.est = item.est;
                    Archive.estTime = item.estTime;
                    Archive.final = item.final;
                    Archive.news = item.news;
                    Archive.newss = item.newss;
                    Archive.pickupdate = item.pickupdate;
                    Archive.Size = item.Size;
                    Archive.priorty = "";
                    Archive.specInstruct = item.specInstruct;
                    Archive.testtext = item.testtext;
                    Archive.two = item.two;
                    Archive.vat = item.vat;
                }
            }
            return PartialView("_Bookings",db.NewBookings.ToList());
        }
        [ChildActionOnly]
        public ActionResult AssignIndex()
        {
            var assignMk2 = db.AssignMk2.Include(a => a.NewBookings).Include(a => a.NewDrivers).Include(a => a.NewTrailers).Include(a => a.NewTruck);

             foreach (var Assign in assignMk2.ToList())
            {
                if (Assign.NewBookings.pickupdate <= DateTime.Now)
                {
                    //Finds the truck makes the capacity and makes it free
                    var FindTruck = db.NewTrucks.Find(Assign.TruckId);
                    FindTruck.Capacity = 0;
                    FindTruck.Status = "Free";
                    if (Assign.NewBookings.pickupdate.AddDays(1) <= DateTime.Now)
                    {
                        //deletes the assign 
                        AssignMk2 RemoveAssignFromTable = db.AssignMk2.Find(Assign.id);
                        db.AssignMk2.Remove(RemoveAssignFromTable);
                        db.SaveChanges();
                    }
                }
            }
            return PartialView("_Assign", db.AssignMk2.ToList());
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

