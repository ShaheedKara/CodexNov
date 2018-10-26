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
    public class drivercheckinMk2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: drivercheckinMk2
        public ActionResult Index()
        {

            string email = User.Identity.Name;
            var s = from a in db.drivercheckinMk2 select a;

            s = s.Where(x => x.email.Equals(email));
            s = s.OrderByDescending(x => x.drivercheckin);
            return View(s);
        }
        public ActionResult AgentIndex()
        {
            return View(db.drivercheckinMk2.ToList().OrderByDescending(x => x.dateandtime).ToList());
        }


        // GET: drivercheckinMk2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drivercheckinMk2 drivercheckinMk2 = db.drivercheckinMk2.Find(id);
            if (drivercheckinMk2 == null)
            {
                return HttpNotFound();
            }
            return View(drivercheckinMk2);
        }

        // GET: drivercheckinMk2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: drivercheckinMk2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "drivercheckin,email,dateandtime,address,lognlat,comment,testtext,testtexts")] drivercheckinMk2 drivercheckinMk2)
        {
            if (ModelState.IsValid)
            {
                drivercheckinMk2.email = User.Identity.Name;
                drivercheckinMk2.dateandtime = DateTime.Now;
                drivercheckinMk2.lognlat = drivercheckinMk2.testtexts;
                drivercheckinMk2.address = drivercheckinMk2.testtext;
                db.drivercheckinMk2.Add(drivercheckinMk2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drivercheckinMk2);
        }

        // GET: drivercheckinMk2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drivercheckinMk2 drivercheckinMk2 = db.drivercheckinMk2.Find(id);
            if (drivercheckinMk2 == null)
            {
                return HttpNotFound();
            }
            return View(drivercheckinMk2);
        }

        // POST: drivercheckinMk2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "drivercheckin,email,dateandtime,address,lognlat,comment,testtext,testtexts")] drivercheckinMk2 drivercheckinMk2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drivercheckinMk2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drivercheckinMk2);
        }

        // GET: drivercheckinMk2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            drivercheckinMk2 drivercheckinMk2 = db.drivercheckinMk2.Find(id);
            if (drivercheckinMk2 == null)
            {
                return HttpNotFound();
            }
            return View(drivercheckinMk2);
        }

        // POST: drivercheckinMk2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            drivercheckinMk2 drivercheckinMk2 = db.drivercheckinMk2.Find(id);
            db.drivercheckinMk2.Remove(drivercheckinMk2);
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
