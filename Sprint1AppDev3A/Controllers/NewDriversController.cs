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
    public class NewDriversController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NewDrivers
        public ActionResult Index()
        {
            return View(db.NewDrivers.ToList());
        }

        // GET: NewDrivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewDriver newDriver = db.NewDrivers.Find(id);
            if (newDriver == null)
            {
                return HttpNotFound();
            }
            return View(newDriver);
        }

        // GET: NewDrivers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewDrivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverId,Id,DriverFullName,Email,contactNumber,DriverStatus,DriverLocation,DriverDestination")] NewDriver newDriver)
        {
            if (ModelState.IsValid)
            {
                db.NewDrivers.Add(newDriver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newDriver);
        }

        // GET: NewDrivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewDriver newDriver = db.NewDrivers.Find(id);
            if (newDriver == null)
            {
                return HttpNotFound();
            }
            return View(newDriver);
        }

        // POST: NewDrivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverId,Id,DriverFullName,Email,contactNumber,DriverStatus,DriverLocation,DriverDestination")] NewDriver newDriver)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(newDriver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newDriver);
        }

        // GET: NewDrivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewDriver newDriver = db.NewDrivers.Find(id);
            if (newDriver == null)
            {
                return HttpNotFound();
            }
            return View(newDriver);
        }

        // POST: NewDrivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewDriver newDriver = db.NewDrivers.Find(id);
            db.NewDrivers.Remove(newDriver);
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
