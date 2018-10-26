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
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Net.Mail;
using System.Text;
using Microsoft.AspNet.Identity;

namespace Sprint1AppDev3A.Controllers
{
    public class NewBookingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NewBookings
        public ActionResult Index()
        {
            string email = User.Identity.GetUserName();
            var s = from a in db.NewBookings select a;
            s = s.Where(x => x.email.Equals(email));
            return View(s);
        }

        public ActionResult Blist()
        {

            string email = User.Identity.GetUserName();
            var s = from a in db.NewBookings select a;
            s = s.Where(x => x.email.Equals(email));
            return View(s);
        }
        public ActionResult clerk()
        {
            return View(db.NewBookings.ToList());
        }

        public ActionResult klerk(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewBooking NewBookings = db.NewBookings.Find(id);


            var doc = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);

            doc.Open();
            doc.Add(new Paragraph("*****OCEAN LAND LOGISTICS*****"));
            doc.Add(new Paragraph("**INVOICE***"));

            doc.Add(new Paragraph("Job Id    :" + NewBookings.BookingIds));
            doc.Add(new Paragraph("Client Name     :" + NewBookings.clientname));
            doc.Add(new Paragraph("Contact Number    :" + NewBookings.cellnum));
            doc.Add(new Paragraph("Client Email     :" + NewBookings.email));


            doc.Add(new Paragraph("Container       :" + NewBookings.ConNum));
            doc.Add(new Paragraph("Container Type  :" + NewBookings.ConType));
            doc.Add(new Paragraph("Trailer Size        :" + NewBookings.Size));
            doc.Add(new Paragraph("Collection        :" + NewBookings.Collection));
            doc.Add(new Paragraph("Drop Off         :" + NewBookings.Dropoff));
            doc.Add(new Paragraph("Total           :R" + NewBookings.final));
            doc.Add(new Paragraph("Vat amount     :R" + NewBookings.vat));


            writer.CloseStream = false;
            doc.Close();
            memoryStream.Position = 0;

            MailMessage mm = new MailMessage(NewBookings.email, NewBookings.email)
            {
                Subject = "OLL invoice for " + NewBookings.BookingIds,
                IsBodyHtml = true,
                Body = " Dear : "+ NewBookings.clientname + " please find attached invoice for  job :" + NewBookings.BookingIds 
            };

            mm.Attachments.Add(new Attachment(memoryStream, "INVOICE.pdf"));
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("CodexInnovations404@gmail.com", "Codex#123")

            };

            smtp.Send(mm);

            if (NewBookings == null)
            {
                return HttpNotFound();
            }
            return View(NewBookings);
        }

        public ActionResult InvoiceDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewBooking NewBookings = db.NewBookings.Find(id);

            if (NewBookings == null)
            {
                return HttpNotFound();
            }
            return View(NewBookings);
        }

        public ActionResult bbdetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewBooking NewBookings = db.NewBookings.Find(id);





            string amount = Convert.ToString(NewBookings.final);
            string orderId = new Random().Next(1, 99999).ToString();
            string name =  NewBookings.ConNum+", Order#" + NewBookings.BookingIds;
            string description = "To "+NewBookings.Dropoff;


            string site = "";
            string merchant_id = "";
            string merchant_key = "";

            // Check if we are using the mmor live system
            string paymentMode = System.Configuration.ConfigurationManager.AppSettings["PaymentMode"];

            if (paymentMode == "test")
            {
                site = "https://sandbox.payfast.co.za/eng/process?";
                merchant_id = "10000100";
                merchant_key = "46f0cd694581a";
            }
            else if (paymentMode == "live")
            {
                site = "https://www.payfast.co.za/eng/process?";
                merchant_id = System.Configuration.ConfigurationManager.AppSettings["PF_MerchantID"];
                merchant_key = System.Configuration.ConfigurationManager.AppSettings["PF_MerchantKey"];
            }
            else
            {
                throw new InvalidOperationException("Cannot process payment if PaymentMode (in web.config) value is unknown.");
            }
            // Build the query string for payment site

            StringBuilder str = new StringBuilder();
            str.Append("merchant_id=" + HttpUtility.UrlEncode(merchant_id));
            str.Append("&merchant_key=" + HttpUtility.UrlEncode(merchant_key));
            str.Append("&return_url=" + HttpUtility.UrlEncode(System.Configuration.ConfigurationManager.AppSettings["PF_ReturnURL"]));
            str.Append("&cancel_url=" + HttpUtility.UrlEncode(System.Configuration.ConfigurationManager.AppSettings["PF_CancelURL"]));
            //str.Append("&notify_url=" + HttpUtility.UrlEncode(System.Configuration.ConfigurationManager.AppSettings["PF_NotifyURL"]));

            str.Append("&m_payment_id=" + HttpUtility.UrlEncode(orderId));
            str.Append("&amount=" + HttpUtility.UrlEncode(amount));
            str.Append("&item_name=" + HttpUtility.UrlEncode(name));
            str.Append("&item_description=" + HttpUtility.UrlEncode(description));

            // Redirect to PayFast
            Response.Redirect(site + str.ToString());

            if (NewBookings == null)
            {
                return HttpNotFound();
            }
            return View(NewBookings);
        }


        // GET: NewBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewBooking newBooking = db.NewBookings.Find(id);
            if (newBooking == null)
            {
                return HttpNotFound();
            }
            return View(newBooking);
        }

        // GET: NewBookings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingIds,pickupdate,clientname,cellnum,email,ConNum,ConType,Size,specInstruct,testtext,two,Distance,final,Collection,Dropoff,priorty,est,estTime,news,newss,vat")] NewBooking newBooking)
        {
            if (ModelState.IsValid)
            {
                //NewContainer container = new NewContainer();
                //container.ContainerID = newBooking.BookingIds;
                //container.ContainerNumber = newBooking.ConNum;
                //container.ContainerSize = newBooking.Size;
                //container.Location = newBooking.news;
                //db.NewContainers.Add(container);
                //db.SaveChanges();
                string neww = newBooking.testtext;
                newBooking.email = User.Identity.Name;
                neww = neww.Replace("km", "");
                neww = neww.Replace(",", "");
                neww = neww.Trim();

                string dist = neww;
                newBooking.two = Convert.ToDouble(neww, CultureInfo.InvariantCulture);
                newBooking.two = Math.Round(newBooking.two);
                newBooking.Distance = newBooking.testtext;

                string dur = newBooking.est.Trim();
                double fest = Convert.ToDouble(dur, CultureInfo.InvariantCulture);
                fest = Math.Round(fest);
                newBooking.estTime = (fest / 60) / 24;
                //prices prices = new prices();
                //booking.final = booking.finalAmt();
                var c = db.Prices.Where(x => x.id == 1);
                double rate = Convert.ToDouble(c.Sum(y => y.rate));
                double s = Convert.ToDouble(c.Sum(a => a.six));
                double t = Convert.ToDouble(c.Sum(v => v.twelve));
                double ta = Convert.ToDouble(c.Sum(w => w.tank));
                double re = Convert.ToDouble(c.Sum(f => f.refridge));
                double p = Convert.ToDouble(c.Sum(e => e.dry));

                double tot = 0.00;

                if (newBooking.Size == "6m" && newBooking.ConType == "Tank")
                {
                    tot = s + ta;
                }
                else if (newBooking.Size == "6m" && newBooking.ConType == "Dry Container")
                {
                    tot = s + p;
                }
                else if (newBooking.Size == "6m" && newBooking.ConType == "Refrigderated ISO")
                {
                    tot = s + re;
                }
                else if (newBooking.Size == "12m" && newBooking.ConType == "Tank")
                {
                    tot = t + ta;
                }
                else if (newBooking.Size == "12m" && newBooking.ConType == "Dry Container")
                {
                    tot = t + p;
                }
                else if (newBooking.Size == "12m" && newBooking.ConType == "Refrigderated ISO")
                {
                    tot = t + re;
                }



                //if (newBooking.two > 550 && newBooking.two < 1500)
                //{
                //    newBooking.priorty = "Medium";
                //   // newBooking.pickupdate = newBooking.pickupdate.AddDays(newBooking.estTime + 2);
                //}
                //else if (newBooking.two > 1500)
                //{
                //    newBooking.priorty = "High";
                //    newBooking.pickupdate = newBooking.pickupdate.AddDays(newBooking.estTime + 3);
                //}
                //else if (newBooking.two < 550)
                //{
                //    newBooking.priorty = "low";
                //    newBooking.pickupdate = newBooking.pickupdate.AddDays(newBooking.estTime + 1);
                //}

                //else
                //{
                //    newBooking.priorty = "Out off Range";
                //}

                var V = db.Vats.Where(u => u.ID == 1);
                double E = Convert.ToDouble(V.Sum(y => y.exempt));
                double st = Convert.ToDouble(V.Sum(y => y.standardRated));
                double z = Convert.ToDouble(V.Sum(y => y.zeroRated));


                double vvat = 0.00;
                if (newBooking.specInstruct == "Perishables")

                {
                    vvat = E + (st / 100) + z;
                }

                else
                {
                    vvat = E + (st / 100);
                }




                newBooking.final = (newBooking.two * rate) + ((tot) * (vvat)) + (newBooking.two * rate) + (tot);
                newBooking.Collection = newBooking.news;
                newBooking.Dropoff = newBooking.newss;
                newBooking.priorty = newBooking.priorty;
                newBooking.vat = newBooking.final * (st / 100);


                db.NewBookings.Add(newBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newBooking);
        }

        // GET: NewBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewBooking newBooking = db.NewBookings.Find(id);
            if (newBooking == null)
            {
              
                return HttpNotFound();
            }
            return View(newBooking);
        }

        // POST: NewBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingIds,pickupdate,clientname,cellnum,email,ConNum,ConType,Size,specInstruct,testtext,two,Distance,final,Collection,Dropoff,priorty,est,estTime,news,newss,vat")] NewBooking newBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newBooking);
        }

        // GET: NewBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewBooking newBooking = db.NewBookings.Find(id);
            if (newBooking == null)
            {
                return HttpNotFound();
            }
            return View(newBooking);
        }

        // POST: NewBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewBooking newBooking = db.NewBookings.Find(id);
            db.NewBookings.Remove(newBooking);
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
        // GET: SpecialPaypal
        //  private ApplicationDbContext db = new ApplicationDbContext();
        //public ActionResult IndexPayPal()
        //{
        //    var cust = db.Customers.ToList().Find(x => x.email.Equals(User.Identity.GetUserName()));

            //    return View(db.orderTickets.Where(x => x.customerId.Equals(cust.customerId) ));
            //}
            //public ActionResult IndexPayPal()
            //{
            //    string EmailFound = "";
            //    if (User.Identity.IsAuthenticated)
            //    {
            //        string UserEmail = User.Identity.GetUserId();
            //        var find = db.Users.Where(m => m.Id.Equals(UserEmail));
            //        foreach (var item in find)
            //        {
            //            EmailFound = item.Email;
            //        }
            //    }
            //    var cust = db.Customers.ToList().Find(x => x.email.Equals(User.Identity.GetUserName()));
            //    return View(db.OrderPackages.Where(m => m.customerId.Equals(cust.customerId)));
            //}
        //public ActionResult SPayFast(int? id)
        //{
            // var email = User.Identity.GetUserName();
            //  var FindEmail = db.Users.Where(m => m.UserName == email);
            //var Del = db.DeliveryOptions.Count(m => m.UserName == email);
            //double delivery = 0;
            //if (Del > 0)
            //{
            //    delivery = 100;
            //}
            //   / /  string EmailFound = "";
            //  foreach (var item in FindEmail)
            // {
            //     EmailFound = item.Email;
            //  }
          //  var nw = db.NewBookings.Find(id);
            //string amount = Session["tot"].ToString();
        

            //return View();
        //}
    }
}