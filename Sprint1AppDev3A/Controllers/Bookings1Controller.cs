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
    public class Bookings1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bookings1
        public ActionResult Index()
        {
            return View(db.Bookings.ToList());
        }

        // GET: Bookings1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookings bookings = db.Bookings.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            return View(bookings);
        }

        // GET: Bookings1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookings1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingIds,pickupdate,clientname,cellnum,email,ConNum,ConType,Size,specInstruct,testtext,two,Distance,final,Collection,Dropoff,priority,est,estTime,news,newss,estimate1")] Bookings bookings)
        {
            if (ModelState.IsValid)
            {


                string neww = bookings.testtext;

                neww = neww.Replace("km", "");
                neww = neww.Replace(",", "");
                neww = neww.Trim();
                
                string dist = neww;
                bookings.two = Convert.ToDouble(neww, CultureInfo.InvariantCulture);
                bookings.two = Math.Round(bookings.two);
                bookings.Distance = bookings.testtext;

                //prices prices = new prices();
                //booking.final = booking.finalAmt();

                var c = db.Prices.Where(x => x.id == 1);
                double r = Convert.ToDouble(c.Sum(y => y.rate));
                double s = Convert.ToDouble(c.Sum(a => a.six));
                double t = Convert.ToDouble(c.Sum(v => v.twelve));
                double ta = Convert.ToDouble(c.Sum(w => w.tank));
                double re = Convert.ToDouble(c.Sum(f => f.refridge));
                double p = Convert.ToDouble(c.Sum(e => e.dry));

                double tot = 0.00;

                if (bookings.Size == "6m" && bookings.ConType == "Tank")
                {
                    tot = s + ta;
                }
                else if (bookings.Size == "6m" && bookings.ConType == "Dry Container")
                {
                    tot = s + p;
                }
                else if (bookings.Size == "6m" && bookings.ConType == "Refrigderated ISO")
                {
                    tot = s + re;
                }
                else if (bookings.Size == "12m" && bookings.ConType == "Tank")
                {
                    tot = t + ta;
                }
                else if (bookings.Size == "12m" && bookings.ConType == "Dry Container")
                {
                    tot = t + p;
                }
                else if (bookings.Size == "12m" && bookings.ConType == "Refrigderated ISO")
                {
                    tot = t + re;
                }



                if (bookings.two > 550 && bookings.two < 1500)
                {
                    bookings.priority = "Medium";
                    bookings.estimate1 = bookings.pickupdate.AddDays(2);
                }
                else if (bookings.two > 1500)
                {
                    bookings.priority = "High";
                    bookings.estimate1 = bookings.pickupdate.AddDays(3);
                }
                else if (bookings.two < 550)
                {
                    bookings.priority = "low";
                    bookings.estimate1 = bookings.pickupdate.AddDays(1);
                }

                else
                {
                    bookings.priority = "Out off Range";
                }

                var V = db.Vats.Where(u => u.ID == 1);
                double E = Convert.ToDouble(V.Sum(y => y.exempt));
                double st = Convert.ToDouble(V.Sum(y => y.standardRated));
                double z = Convert.ToDouble(V.Sum(y => y.zeroRated));


                double vvat = 0.00;
                if (bookings.specInstruct == "Perishables")

                {
                    vvat = E + (st / 100) + z;
                }

                else
                {
                    vvat = E + (st / 100);
                }




                bookings.final = (bookings.two * r) + ((tot) * (vvat)) + (bookings.two * r) + (tot);
                bookings.Collection = bookings.news;
                bookings.Dropoff = bookings.newss;
                bookings.priority = bookings.priority;
                bookings.Distance = bookings.testtext;
                //bookings.estTime = bookings.estTime;

                db.Bookings.Add(bookings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookings);
        }

        // GET: Bookings1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookings bookings = db.Bookings.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            return View(bookings);
        }

        // POST: Bookings1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingIds,pickupdate,clientname,cellnum,email,ConNum,ConType,Size,specInstruct,testtext,two,Distance,final,Collection,Dropoff,priority,est,estTime,news,newss,estimate1")] Bookings bookings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookings);
        }

        // GET: Bookings1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bookings bookings = db.Bookings.Find(id);
            if (bookings == null)
            {
                return HttpNotFound();
            }
            return View(bookings);
        }

        // POST: Bookings1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bookings bookings = db.Bookings.Find(id);
            db.Bookings.Remove(bookings);
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
