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
    public class NewNEWAssignsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NewNEWAssigns
        public ActionResult Index()
        {
            var newNEWAssigns = db.NewNEWAssigns.Include(n => n.ContainerID);
            return View(newNEWAssigns.ToList());
        }

        // GET: NewNEWAssigns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewNEWAssign newNEWAssign = db.NewNEWAssigns.Find(id);
            if (newNEWAssign == null)
            {
                return HttpNotFound();
            }
            return View(newNEWAssign);
        }

        // GET: NewNEWAssigns/Create
        public ActionResult Create()
        {
            ViewBag.ContID = new SelectList(db.NewContainers, "ContainerID", "ContainerNumber");
            return View();
        }

        // POST: NewNEWAssigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignID,ContID,SelectedDate,ContainerNumber,ContainerSize,Driver,Truck,Trailer,Location,Destination,Status,PickUpTime,PickUpDate,EstDate,EstTime,AssignCode")] NewNEWAssign newNEWAssign)
        {
            if (ModelState.IsValid)
            {
                

                    var containers = db.NewContainers.Where(x => x.Status == "UnAssigned" && x.PickUp == newNEWAssign.SelectedDate).ToList();

                    var Priority1 = containers.Where(x => x.Priority == "High").ToList();
                    var Priority2 = containers.Where(x => x.Priority == "Medium").ToList();
                    var Priority3 = containers.Where(x => x.Priority == "Low").ToList();

                    var FreeDri = db.DatesBookedDrivers.Where(x => x.PickUpDate != newNEWAssign.SelectedDate).ToList();
                    var FreeTru = db.DatesBookedTrucks.Where(x => x.PickUpDate != newNEWAssign.SelectedDate).ToList();
                    var FreeTra = db.DatesBookedTrailers.Where(x => x.PickUpDate != newNEWAssign.SelectedDate).ToList();

                    foreach (var item in Priority1)
                    {
                        if (FreeDri != null && FreeTra != null && FreeTru != null)
                        {
                            try
                            {
                                var Pri1 = Priority1.Where(x => x.Status == "UnAssigned").First();
                                var Dri = FreeDri.Where(x => x.PickUpDate != newNEWAssign.SelectedDate).First();
                                var DriverYeah = db.NewDrivers.Find(Dri.DriveID);
                                var Tru = FreeTru.Where(x => x.PickUpDate != newNEWAssign.SelectedDate).First();
                                var TruckYeah = db.NewTrucks.Find(Dri.DriveID);
                                var Tra = FreeTra.Where(x => x.PickUpDate != newNEWAssign.SelectedDate).First();
                                var TrailerYeah = db.NewTrailers.Find(Dri.DriveID);

                                NewNEWAssign obj = new NewNEWAssign();
                                obj.AssignID = Pri1.ContainerID;
                                obj.PickUpDate = Pri1.PickUp;
                                obj.PickUpTime = Pri1.PickUpTime;
                                obj.ContainerNumber = Pri1.ContainerNumber;
                                obj.ContainerSize = Pri1.ContainerSize;
                                obj.Location = Pri1.Location;
                                obj.Destination = Pri1.Destination;

                                ////////
                                ////////

                                obj.Driver = DriverYeah.Email;
                                obj.Trailer = TrailerYeah.reg;
                                obj.Truck = TruckYeah.reg;


                                Pri1.Status = "Pending";
                                Dri.PickUpDate = newNEWAssign.SelectedDate;
                                Tra.PickUpDate = newNEWAssign.SelectedDate;
                                Tru.PickUpDate = newNEWAssign.SelectedDate;

                            }
                            catch (Exception)
                            {


                            }
                        }
                        else
                        {
                            foreach (var item1 in Priority1)
                            {
                                var Pri1 = Priority1.Where(x => x.Status == "UnAssigned" && x.PickUp == newNEWAssign.SelectedDate).First();
                                Pri1.PickUp = Pri1.PickUp.AddDays(1);

                            }

                        }
                    }

                   
                        foreach (var item in Priority2)
                        {
                            if (FreeDri != null && FreeTra != null && FreeTru != null)
                            {
                                try
                                {
                                    var Pri2 = Priority2.Where(x => x.Status == "UnAssigned").First();
                                    var Dri = FreeDri.Where(x => x.PickUpDate != newNEWAssign.SelectedDate).First();
                                    var DriverYeah = db.NewDrivers.Find(Dri.DriveID);
                                    var Tru = FreeTru.Where(x => x.PickUpDate != newNEWAssign.SelectedDate).First();
                                    var TruckYeah = db.NewTrucks.Find(Dri.DriveID);
                                    var Tra = FreeTra.Where(x => x.PickUpDate != newNEWAssign.SelectedDate).First();
                                    var TrailerYeah = db.NewTrailers.Find(Dri.DriveID);

                                    NewNEWAssign obj = new NewNEWAssign();
                                    obj.AssignID = Pri2.ContainerID;
                                    obj.PickUpDate = Pri2.PickUp;
                                    obj.PickUpTime = Pri2.PickUpTime;
                                    obj.ContainerNumber = Pri2.ContainerNumber;
                                    obj.ContainerSize = Pri2.ContainerSize;
                                    obj.Location = Pri2.Location;
                                    obj.Destination = Pri2.Destination;

                                    ////////
                                    ////////

                                    obj.Driver = DriverYeah.Email;
                                    obj.Trailer = TrailerYeah.reg;
                                    obj.Truck = TruckYeah.reg;


                                    Pri2.Status = "Pending";
                                    Dri.PickUpDate = newNEWAssign.SelectedDate;
                                    Tra.PickUpDate = newNEWAssign.SelectedDate;
                                    Tru.PickUpDate = newNEWAssign.SelectedDate;

                                }
                                catch (Exception)
                                {


                                }
                            }
                        else
                        {
                            foreach (var item2 in Priority2)
                            {
                                var Pri2 = Priority2.Where(x => x.Status == "UnAssigned" && x.PickUp == newNEWAssign.SelectedDate).First();
                                Pri2.PickUp = Pri2.PickUp.AddDays(1);

                            }

                        }
                    }
                    

                      foreach (var item in Priority3)
                        {
                            if (FreeDri != null && FreeTra != null && FreeTru != null)
                            {
                                try
                                {
                                    var Pri3 = Priority3.Where(x => x.Status == "UnAssigned").First();
                                    var Dri = FreeDri.Where(x => x.PickUpDate != newNEWAssign.SelectedDate).First();
                                    var DriverYeah = db.NewDrivers.Find(Dri.DriveID);
                                    var Tru = FreeTru.Where(x => x.PickUpDate != newNEWAssign.SelectedDate).First();
                                    var TruckYeah = db.NewTrucks.Find(Dri.DriveID);
                                    var Tra = FreeTra.Where(x => x.PickUpDate != newNEWAssign.SelectedDate).First();
                                    var TrailerYeah = db.NewTrailers.Find(Dri.DriveID);

                                    NewNEWAssign obj = new NewNEWAssign();
                                    obj.AssignID = Pri3.ContainerID;
                                    obj.PickUpDate = Pri3.PickUp;
                                    obj.PickUpTime = Pri3.PickUpTime;
                                    obj.ContainerNumber = Pri3.ContainerNumber;
                                    obj.ContainerSize = Pri3.ContainerSize;
                                    obj.Location = Pri3.Location;
                                    obj.Destination = Pri3.Destination;

                                    ////////
                                    ////////

                                    obj.Driver = DriverYeah.Email;
                                    obj.Trailer = TrailerYeah.reg;
                                    obj.Truck = TruckYeah.reg;


                                    Pri3.Status = "Pending";
                                    Dri.PickUpDate = newNEWAssign.SelectedDate;
                                    Tra.PickUpDate = newNEWAssign.SelectedDate;
                                    Tru.PickUpDate = newNEWAssign.SelectedDate;

                                }
                                catch (Exception)
                                {


                                }
                            }
                        else
                        {
                            foreach (var item3 in Priority3)
                            {
                                var Pri3 = Priority3.Where(x => x.Status == "UnAssigned" && x.PickUp == newNEWAssign.SelectedDate).First();
                                Pri3.PickUp = Pri3.PickUp.AddDays(1);

                            }

                        }

                    }
                   




            

               









                db.NewNEWAssigns.Add(newNEWAssign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContID = new SelectList(db.NewContainers, "ContainerID", "ContainerNumber", newNEWAssign.ContID);
            return View(newNEWAssign);
        }

        // GET: NewNEWAssigns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewNEWAssign newNEWAssign = db.NewNEWAssigns.Find(id);
            if (newNEWAssign == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContID = new SelectList(db.NewContainers, "ContainerID", "ContainerNumber", newNEWAssign.ContID);
            return View(newNEWAssign);
        }

        // POST: NewNEWAssigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignID,ContID,SelectedDate,ContainerNumber,ContainerSize,Driver,Truck,Trailer,Location,Destination,Status,PickUpTime,PickUpDate,EstDate,EstTime,AssignCode")] NewNEWAssign newNEWAssign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newNEWAssign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContID = new SelectList(db.NewContainers, "ContainerID", "ContainerNumber", newNEWAssign.ContID);
            return View(newNEWAssign);
        }

        // GET: NewNEWAssigns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewNEWAssign newNEWAssign = db.NewNEWAssigns.Find(id);
            if (newNEWAssign == null)
            {
                return HttpNotFound();
            }
            return View(newNEWAssign);
        }

        // POST: NewNEWAssigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewNEWAssign newNEWAssign = db.NewNEWAssigns.Find(id);
            db.NewNEWAssigns.Remove(newNEWAssign);
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
