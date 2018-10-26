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
    public class NewAssignsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NewAssigns
        public ActionResult Index()
        {
            var newAssigns = db.NewAssigns.Include(n => n.ContainerID);
            return View(newAssigns.ToList());
        }

        // GET: NewAssigns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewAssign newAssign = db.NewAssigns.Find(id);
            if (newAssign == null)
            {
                return HttpNotFound();
            }
            return View(newAssign);
        }

        // GET: NewAssigns/Create
        public ActionResult Create()
        {
            ViewBag.ContID = new SelectList(db.NewContainers.Where(x=>x.Status=="UnAssigned"), "ContainerID", "ContainerNumber");
            return View();
        }

        // POST: NewAssigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignID,ContID,ContainerNumber,ContainerSize,Driver,Driverid,Truck,Trailer,Location,Destination,Status,DeadLine,PickUp,ActualPick,ActualDrop")] NewAssign newAssign)
        {
            if (ModelState.IsValid)
            {
                ////var ID = db.NewContainers.Find(bookings.BookingIds);
                ////ID.ContainerID = bookings.BookingIds;

                //var Cont = db.NewContainers.Find(newAssign.ContID);

                ////newAssign.ContainerSize = Cont.ContainerSize;
                ////newAssign.ContainerNumber = Cont.ContainerNumber;
                ////newAssign.Location = Cont.Location;
                ////newAssign.DeadLine = Cont.DeadLine;
                ////newAssign.PickUp = Cont.PickUp;
                ////newAssign.Destination = Cont.Destination;
                ////newAssign.PickUpTime = Cont.PickUpTime;
                ////newAssign.DropOffTime = Cont.DropoffTime;
                ////newAssign.EstTime = Cont.DropoffTime;

                //if (Cont != null)
                //{
                //    int flag = 0;
                //    try
                //    {
                //        do
                //        {
                //            var TrailList = db.NewTrailers.Where(x => x.TrailerSize == Cont.ContainerSize
                //                                                                && x.Status == "StandBy"
                //                                                                && x.Location == Cont.Location).ToList();
                                                                                

                //            var Trail = TrailList.First();
                //            newAssign.Trailer = Trail.reg;
                //            Trail.Status = "Booked";
                //            Trail.Destination = newAssign.Destination;

                //            var TruckList = db.NewTrucks.Where(x => x.Location == Cont.Location
                //                                                            && x.Status == "StandBy").ToList();

                //            var Truc = TruckList.First();
                //            newAssign.Truck = Truc.reg;
                //            Truc.Status = "Booked";
                //            Truc.Destination = newAssign.Destination;


                //            var DriverList = db.NewDrivers.Where(x => x.DriverLocation == Cont.Location
                //                                                            && x.DriverStatus == "StandBy").ToList();

                //            var Drive = DriverList.First();
                //            newAssign.Driver = Drive.Email;
                //            newAssign.Driverid = Drive.DriverId.ToString();
                //            Drive.DriverStatus = "Booked";
                //            Drive.DriverDestination = newAssign.Destination;

                //            newAssign.EstTime = newAssign.EstTime.AddDays(1);

                //        } while (flag != 3);
                //    }
                //    catch (Exception)
                //    {

                //        throw;
                //    }


                //    Cont.Status = "Assigned";
                //    newAssign.AssignCode = newAssign.GenAssCode();
                //    db.NewAssigns.Add(newAssign);
                //    db.SaveChanges();
                //    return RedirectToAction("Index");
                //}

                
            }

            ViewBag.ContID = new SelectList(db.NewContainers, "ContainerID", "ContainerNumber", newAssign.ContID);
            return View(newAssign);
        }

        // GET: NewAssigns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewAssign newAssign = db.NewAssigns.Find(id);
            if (newAssign == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContID = new SelectList(db.NewContainers, "ContainerID", "ContainerNumber", newAssign.ContID);
            return View(newAssign);
        }

        // POST: NewAssigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignID,ContID,ContainerNumber,Driver,Truck,Trailer,Location,Destination,Status,DeadLine,PickUp,ActualPick,ActualDrop")] NewAssign newAssign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newAssign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContID = new SelectList(db.NewContainers, "ContainerID", "ContainerNumber", newAssign.ContID);
            return View(newAssign);
        }

        // GET: NewAssigns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewAssign newAssign = db.NewAssigns.Find(id);
            if (newAssign == null)
            {
                return HttpNotFound();
            }
            return View(newAssign);
        }

        // POST: NewAssigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewAssign newAssign = db.NewAssigns.Find(id);
            db.NewAssigns.Remove(newAssign);
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
