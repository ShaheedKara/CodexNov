using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sprint1AppDev3A.Models;

namespace Sprint1AppDev3A.Controllers
{
    public class AssignCascadesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AssignCascades
        public ActionResult Index()
        {
            var assignCascades = db.AssignCascades.Include(a => a.BookingId).Include(a => a.TruckId);
            return View(assignCascades.ToList());
        }

        // GET: AssignCascades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignCascade assignCascade = db.AssignCascades.Find(id);
            if (assignCascade == null)
            {
                return HttpNotFound();
            }
            return View(assignCascade);
        }
        public ActionResult TimeTable()
        {
            return View();
        }
        // GET: AssignCascades/Create
        public ActionResult Create()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            AssignCascade dbA = new AssignCascade();
            Truck dbT = new Truck();

         //   dbA.TrucksDatesBooked = dbT.TrucksDatesBooked;

          

            ViewBag.BookID = new SelectList(db.Bookings.Where(x => x.Assigned ==false), "BookingId", "ContainerNum");
            ViewBag.TrucksID = new SelectList(db.Trucks.Where(x =>x.Available==true), "TruckId", "reg");
            return View();
        }

        public ActionResult CascadeTruck(string TrailerSelect)
        {
            db.Configuration.ProxyCreationEnabled = true;
            List<Truck> TruckList = db.Trucks.Where(x => x.TrailerSize == TrailerSelect && x.Available == (true)).ToList();

            return Json(TruckList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CascadeCont(string TrailerSelect)
        {
            db.Configuration.ProxyCreationEnabled = true;
            List<Booking> ContList = db.Bookings.Where(x => x.ContainerSize == TrailerSelect && x.Assigned == (false)).ToList();
            return Json(ContList, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Dates()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<Truck> TruckList = db.Trucks.ToList<Truck>();
                return Json(new { data = TruckList }, JsonRequestBehavior.AllowGet);
            }

        }
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ConnectionString;
        public JsonResult GetDateBooked()
        {
            List<Truck> TruckD = new List<Truck>();
            string query = string.Format("Select * From Employee");
            SqlConnection connection = new SqlConnection(connectionString);
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TruckD.Add(
                            new Truck
                            {


                                //EmpId = int.Parse(reader["EmpId"].ToString()),
                                //EmpName = reader.GetValue(0).ToString(),

                                TrucksDatesBooked = reader.GetValue(0).ToString()

                            }
                        );
                    }
                }
                return Json(TruckD, JsonRequestBehavior.AllowGet);
            }
        }



        // POST: AssignCascades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignID,SizeCheck,TrucksID,BookID, TrucksDatesBooked")] AssignCascade assignCascade)
        {
            if (ModelState.IsValid)
            {
                db.AssignCascades.Add(assignCascade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.Bookings, "BookingId", "ContainerNum", assignCascade.BookID);
            ViewBag.TrucksID = new SelectList(db.Trucks, "TruckId", "TrailerSize", assignCascade.TrucksID);
            return View(assignCascade);
        }

        // GET: AssignCascades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignCascade assignCascade = db.AssignCascades.Find(id);
            if (assignCascade == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.Bookings, "BookingId", "refNumber", assignCascade.BookID);
            ViewBag.TrucksID = new SelectList(db.Trucks, "TruckId", "TrailerSize", assignCascade.TrucksID);
            return View(assignCascade);
        }

        // POST: AssignCascades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignID,SizeCheck,TrucksID,BookID")] AssignCascade assignCascade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignCascade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.Bookings, "BookingId", "refNumber", assignCascade.BookID);
            ViewBag.TrucksID = new SelectList(db.Trucks, "TruckId", "TrailerSize", assignCascade.TrucksID);
            return View(assignCascade);
        }

        // GET: AssignCascades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignCascade assignCascade = db.AssignCascades.Find(id);
            if (assignCascade == null)
            {
                return HttpNotFound();
            }
            return View(assignCascade);
        }

        // POST: AssignCascades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignCascade assignCascade = db.AssignCascades.Find(id);
            db.AssignCascades.Remove(assignCascade);
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
