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
    public class AssignsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Assigns
        [Authorize(Roles = "Agent")]
        public ActionResult Index()
        {
            var assigns = db.Assigns.Include(a => a.BookingIds).Include(a => a.DriverId).Include(a => a.TruckId);
            return View(assigns.ToList());
        }

        // GET: Assigns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assign assign = db.Assigns.Find(id);
            if (assign == null)
            {
                return HttpNotFound();
            }
            return View(assign);
        }

        // GET: Assigns/Create
        public ActionResult Create()
        {
         // ViewBag.BookID = new SelectList(db.Bookings.Where(x => x.Assigned == false), "BookingIds", "ConNum");
            ViewBag.DriveID = new SelectList(db.Drivers.Where(x => x.DriAvailable == true), "DriverId", "DriverFullName");
            ViewBag.TrucksID = new SelectList(db.Trucks.Where(x => x.Available == true ), "TruckId", "reg");

            return View();
        }
        public ActionResult CascadeTruck(string TrailerSelect)
        {
            db.Configuration.ProxyCreationEnabled = true;
            List<Truck> TruckList = db.Trucks.Where(x => x.TrailerSize == TrailerSelect && x.Available == (true)).ToList();

            return Json(TruckList, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult CascadeCont(string TrailerSelect)
        //{
        //    db.Configuration.ProxyCreationEnabled = true;
        //  //  List<Bookings> ContList = db.Bookings.Where(x => x.ConType == TrailerSelect && x.As signed == (false)).ToList();
        // //   return Json(ContList, JsonRequestBehavior.AllowGet);
        //}

        // POST: Assigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignID,BookID,DriveID,TrucksID")] Assign assign)
        {
            if (ModelState.IsValid)
            {
                var Book = db.Bookings.Find(assign.BookID);
             //   Book.Assigned = true;
                var Driv = db.Drivers.Find(assign.DriveID);
                Driv.DriAvailable = false;
                var Truc = db.Trucks.Find(assign.TrucksID);
                Truc.Available = false;

                db.Assigns.Add(assign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.Bookings, "BookingIds", "ConNum", assign.BookID);
            ViewBag.DriveID = new SelectList(db.Drivers, "DriverId", "DriverFullName", assign.DriveID);
            ViewBag.TrucksID = new SelectList(db.Trucks, "TruckId", "reg", assign.TrucksID);
            return View(assign);
        }

        // GET: Assigns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assign assign = db.Assigns.Find(id);
            if (assign == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.Bookings, "BookingIds", "ConNum", assign.BookID);
            ViewBag.DriveID = new SelectList(db.Drivers, "DriverId", "Id", assign.DriveID);
            ViewBag.TrucksID = new SelectList(db.Trucks, "TruckId", "TrailerSize", assign.TrucksID);
            return View(assign);
        }

        // POST: Assigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignID,BookID,DriveID,TrucksID")] Assign assign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.Bookings, "BookingIds", "ConNum", assign.BookID);
            ViewBag.DriveID = new SelectList(db.Drivers, "DriverId", "Id", assign.DriveID);
            ViewBag.TrucksID = new SelectList(db.Trucks, "TruckId", "TrailerSize", assign.TrucksID);
            return View(assign);
        }

        // GET: Assigns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assign assign = db.Assigns.Find(id);
            if (assign == null)
            {
                return HttpNotFound();
            }
            return View(assign);
        }

        // POST: Assigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assign assign = db.Assigns.Find(id);
            db.Assigns.Remove(assign);
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
