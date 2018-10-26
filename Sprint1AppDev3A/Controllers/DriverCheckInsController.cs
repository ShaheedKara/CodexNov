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
    public class DriverCheckInsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DriverCheckIns
        public ActionResult Index()
        {
            string email = User.Identity.Name;
            var s = from a in db.DriverCheckIns select a;
            
            s = s.Where(x => x.DriverEmail.Equals(email));
            s = s.OrderByDescending(x => x.CheckID);
            return View(s);
            
        }
        public ActionResult AgentIndex()
        {
            return View(db.DriverCheckIns.ToList().OrderByDescending(x=>x.CheckID));
        }

        // GET: DriverCheckIns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverCheckIn driverCheckIn = db.DriverCheckIns.Find(id);
            if (driverCheckIn == null)
            {
                return HttpNotFound();
            }
            return View(driverCheckIn);
        }

        // GET: DriverCheckIns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DriverCheckIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CheckID,DriverEmail,TimeStamp,Status,Comment,job")] DriverCheckIn driverCheckIn)
        {
            if (ModelState.IsValid)
            {
                        
                driverCheckIn.DriverEmail = User.Identity.Name.ToString();
                var CurrJob = db.NewAssigns.Where(x => x.Driver == driverCheckIn.DriverEmail).First();
                driverCheckIn.job = CurrJob.AssignCode;

                var Drive = db.NewDrivers.Where(x => x.Email == CurrJob.Driver).First();
                var Trial = db.NewTrailers.Where(x => x.reg == CurrJob.Trailer).First();
                var Truc= db.NewTrucks.Where(x => x.reg == CurrJob.Truck).First();
                var cont = db.NewContainers.Where(x => x.ContainerNumber == CurrJob.ContainerNumber).First();
                var book = db.Bookings.Where(x => x.ConNum == cont.ContainerNumber).First();

                //new { value = "Leaving Yard", text = "Leaving Yard" },
                //      new { value = "Reached Depot", text = "Reached Depot" },
                //       new { value = "Loading Truck", text = "Loading Truck" },
                //      new { value = "Leaving Depot", text = "Leaving Depot" },
                //       new { value = "Reached Drop Off", text = "Reached Drop Off" },
                //        new { value = "Unloading Container", text = "Unloading Container" },
                //        new { value = "Returning to Yard", text = "Returning to Yard" },
                //         new { value = "In Yard", text = "In Yard" }





                    Trial.Status = driverCheckIn.Status;
                    Truc.Status = driverCheckIn.Status;

                if (driverCheckIn.Status=="Reached Depot")
                {
                    //Drive.DriverLocation = book.ColCity;
                    //Trial.Location = book.ColCity;
                    //Truc.Location = book.ColCity;
                }
                if (driverCheckIn.Status == "Reached Drop Off")
                {
                
                }



                if (driverCheckIn.Status== "In Yard")
                {
                    
                }
               
               


                driverCheckIn.getTime();
                db.DriverCheckIns.Add(driverCheckIn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(driverCheckIn);
        }

        // GET: DriverCheckIns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverCheckIn driverCheckIn = db.DriverCheckIns.Find(id);
            if (driverCheckIn == null)
            {
                return HttpNotFound();
            }
            return View(driverCheckIn);
        }

        // POST: DriverCheckIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CheckID,DriverName,TimeStamp,Status,Comment")] DriverCheckIn driverCheckIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driverCheckIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driverCheckIn);
        }

        // GET: DriverCheckIns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverCheckIn driverCheckIn = db.DriverCheckIns.Find(id);
            if (driverCheckIn == null)
            {
                return HttpNotFound();
            }
            return View(driverCheckIn);
        }

        // POST: DriverCheckIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DriverCheckIn driverCheckIn = db.DriverCheckIns.Find(id);
            db.DriverCheckIns.Remove(driverCheckIn);
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
