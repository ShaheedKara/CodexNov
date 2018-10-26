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
    public class accountantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: accountants
        public ActionResult Index()
        {




            return View(db.accountants.ToList());
        }

        // GET: accountants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accountant accountant = db.accountants.Find(id);
            if (accountant == null)
            {
                return HttpNotFound();
            }
            return View(accountant);
        }

        // GET: accountants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: accountants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Insurance,mobileCost,telephoneCost,electricity,rent,officeSupplies,sanitarySupplies,month")] accountant accountant)
        {
            if (ModelState.IsValid)
            {

                var Tlist = db.NewTrucks.ToList();
                double tinsurance = 0.00;
                foreach (var item in Tlist)
                {
                    tinsurance = tinsurance + item.insurance;
                }

                var mlist = db.Maintenances.ToList();
                double tmaintence = 0.00;
                foreach (var item in mlist)
                {
                    tmaintence = tmaintence + item.MaintainPrice;
                }





                accountant.month = accountant.monthly() + tinsurance + tmaintence;


                db.accountants.Add(accountant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountant);
        }

        // GET: accountants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accountant accountant = db.accountants.Find(id);
            if (accountant == null)
            {
                return HttpNotFound();
            }
            return View(accountant);
        }

        // POST: accountants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Insurance,mobileCost,telephoneCost,electricity,rent,officeSupplies,sanitarySupplies,month")] accountant accountant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountant);
        }

        // GET: accountants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accountant accountant = db.accountants.Find(id);
            if (accountant == null)
            {
                return HttpNotFound();
            }
            return View(accountant);
        }

        // POST: accountants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            accountant accountant = db.accountants.Find(id);
            db.accountants.Remove(accountant);
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
