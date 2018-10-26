using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sprint1AppDev3A.Models;
using System.Globalization;

namespace Sprint1AppDev3A.Controllers
{
    public class Freequotes1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Freequotes1
        public ActionResult Index()
        {
            return View(db.Freequotes.ToList());
        }

        // GET: Freequotes1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Freequote freequote = db.Freequotes.Find(id);
            if (freequote == null)
            {
                return HttpNotFound();
            }
            return View(freequote);
        }

        // GET: Freequotes1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Freequotes1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "freeQuote,ConsumerName,email,Size,weight,CollectionDate,deliveryDate,contactCell,contactwork,testtext,two,Collection,Dropoff,finna")] Freequote freequote)
        {
            if (ModelState.IsValid)
            {
                var s = db.CalAmts.Where(x => x.id == 1);
                double f = Convert.ToDouble(s.Sum(y => y.fuel));
                double vat = Convert.ToDouble(db.Vats.Sum(x=>x.vat)); // Convert.ToDouble(s.Sum(b => b.Vat));
                double rate = Convert.ToDouble(s.Sum(m => m.Rate));
                string neww = freequote.testtext;

                neww = neww.Replace("km", "");
                neww = neww.Replace(",", "");
                neww = neww.Trim();

                string dist = neww;
                freequote.two = Convert.ToDouble(neww, CultureInfo.InvariantCulture);
                freequote.two = Math.Round(freequote.two);

                freequote.finna = (f * freequote.two*(vat/100)*(rate/100));

                db.Freequotes.Add(freequote);
                db.SaveChanges();
                return RedirectToAction("Details/" + freequote.freeQuote);
            }

            return View(freequote);
        }

        // GET: Freequotes1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Freequote freequote = db.Freequotes.Find(id);
            if (freequote == null)
            {
                return HttpNotFound();
            }
            return View(freequote);
        }

        // POST: Freequotes1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "freeQuote,ConsumerName,email,Size,weight,CollectionDate,deliveryDate,contactCell,contactwork,testtext,two,Collection,Dropoff,finna")] Freequote freequote)
        {
            if (ModelState.IsValid)
            {
               
                db.Entry(freequote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(freequote);
        }

        // GET: Freequotes1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Freequote freequote = db.Freequotes.Find(id);
            if (freequote == null)
            {
                return HttpNotFound();
            }
            return View(freequote);
        }

        // POST: Freequotes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Freequote freequote = db.Freequotes.Find(id);
            db.Freequotes.Remove(freequote);
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
