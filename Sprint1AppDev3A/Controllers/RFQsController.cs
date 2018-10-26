using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sprint1AppDev3A.Models;
using Microsoft.AspNet.Identity;

namespace Sprint1AppDev3A.Controllers
{
    public class RFQsController : Controller

    {
        public ActionResult ExampleCreateView()
        {
            ViewBag.Message = "Your create view page.";
            return View();
        }
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RFQs
        public ActionResult Index()
        {
            string email = User.Identity.GetUserName();
            var s = from a in db.rfq select a;
            s = s.Where(x =>x.Email.Equals(email));
            return View(s);
        }
        
        public ActionResult AgentIndex()
        {
            return View(db.rfq.ToList());
        }
        [HttpPost]
        public ActionResult AgentIndex(string s)
        {
            var search = db.Expenses.Where(x => x.RFQs.Email.Contains(s)).ToList();
            return View(search);
        }
        // GET: RFQs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RFQ rFQ = db.rfq.Find(id);
            if (rFQ == null)
            {
                return HttpNotFound();
            }
            return View(rFQ);
        }

        // GET: RFQs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RFQs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuoteRequestNo,Size,PUDepot,SysDate,DelStreetNum,DelStreetName,DelArea,DelCity,DelCode,Instruct,price,Email")] RFQ obj)
        {
            if (ModelState.IsValid)
            {
                obj.price = obj.CalcTotal();
                obj.SysDate = System.DateTime.Now;
                obj.Email = User.Identity.GetUserName();
                db.rfq.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Details/" + obj.QuoteRequestNo);
            }

            return View(obj);
        }

        // GET: RFQs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RFQ rFQ = db.rfq.Find(id);
            if (rFQ == null)
            {
                return HttpNotFound();
            }
            return View(rFQ);
        }

        // POST: RFQs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuoteRequestNo,Size,PUDepot,SysDate,DelStreetNum,DelStreetName,DelArea,DelCity,DelCode,Instruct,price,Email")] RFQ rFQ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rFQ).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rFQ);
        }

        // GET: RFQs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RFQ rFQ = db.rfq.Find(id);
            if (rFQ == null)
            {
                return HttpNotFound();
            }
            return View(rFQ);
        }

        // POST: RFQs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RFQ rFQ = db.rfq.Find(id);
            db.rfq.Remove(rFQ);
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
