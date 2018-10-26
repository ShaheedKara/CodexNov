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
    public class CheckOut2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CheckOut2
        public ActionResult Index()
        {
            return View(db.CheckOut2s.ToList());
        }

        // GET: CheckOut2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckOut2 checkOut2 = db.CheckOut2s.Find(id);
            if (checkOut2 == null)
            {
                return HttpNotFound();
            }
            return View(checkOut2);
        }

        // GET: CheckOut2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckOut2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CheckOutDate,name,CheckinDate")] CheckOut2 checkOut2)
        {
            if (ModelState.IsValid)
            {
                var Tlist = db.NewDrivers.Find(checkOut2.ID);
                string iname = " ";

                iname = Tlist.DriverFullName;
                checkOut2.name = iname;

                var tlist = db.Checkin.Find(checkOut2.ID);
                DateTime icheckin;
                icheckin = tlist.CheckInDate;
                checkOut2.CheckinDate = icheckin;



                checkOut2.CheckOutDate = System.DateTime.UtcNow;

                db.CheckOut2s.Add(checkOut2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(checkOut2);
        }

        // GET: CheckOut2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckOut2 checkOut2 = db.CheckOut2s.Find(id);
            if (checkOut2 == null)
            {
                return HttpNotFound();
            }
            return View(checkOut2);
        }

        // POST: CheckOut2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CheckOutDate,name,CheckinDate")] CheckOut2 checkOut2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(checkOut2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(checkOut2);
        }

        // GET: CheckOut2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CheckOut2 checkOut2 = db.CheckOut2s.Find(id);
            if (checkOut2 == null)
            {
                return HttpNotFound();
            }
            return View(checkOut2);
        }

        // POST: CheckOut2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CheckOut2 checkOut2 = db.CheckOut2s.Find(id);
            db.CheckOut2s.Remove(checkOut2);
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
