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
    public class maintainsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: maintains
        public ActionResult Index()
        {
            return View(db.Maintains.ToList());
        }

        // GET: maintains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            maintain maintain = db.Maintains.Find(id);
            if (maintain == null)
            {
                return HttpNotFound();
            }
            return View(maintain);
        }

        // GET: maintains/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: maintains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaintainID,TruckId,TrailerID,MaintainDes,MaintainPrice,Mdate,MTechnician")] maintain maintain)
        {
            if (ModelState.IsValid)
            {
                db.Maintains.Add(maintain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maintain);
        }

        // GET: maintains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            maintain maintain = db.Maintains.Find(id);
            if (maintain == null)
            {
                return HttpNotFound();
            }
            return View(maintain);
        }

        // POST: maintains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaintainID,TruckId,TrailerID,MaintainDes,MaintainPrice,Mdate,MTechnician")] maintain maintain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maintain);
        }

        // GET: maintains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            maintain maintain = db.Maintains.Find(id);
            if (maintain == null)
            {
                return HttpNotFound();
            }
            return View(maintain);
        }

        // POST: maintains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            maintain maintain = db.Maintains.Find(id);
            db.Maintains.Remove(maintain);
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
