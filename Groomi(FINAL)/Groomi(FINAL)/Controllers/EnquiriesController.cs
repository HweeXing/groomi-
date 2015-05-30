using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Groomi_FINAL_.Models;

namespace Groomi_FINAL_.Controllers
{
    public class EnquiriesController : Controller
    {
        private Model1 db = new Model1();

        // GET: Enquiries
        public ActionResult Index()
        {
            return View(db.Enquiries.ToList());
        }

        // GET: Enquiries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enquiry enquiry = db.Enquiries.Find(id);
            if (enquiry == null)
            {
                return HttpNotFound();
            }
            return View(enquiry);
        }

        // GET: Enquiries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enquiries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Remarks")] Enquiry enquiry)
        {
            if (ModelState.IsValid)
            {
                db.Enquiries.Add(enquiry);
                db.SaveChanges();
                return RedirectToAction("EnquiriesAdmin", "Home");
            }

            return View(enquiry);
        }

        // GET: Enquiries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enquiry enquiry = db.Enquiries.Find(id);
            if (enquiry == null)
            {
                return HttpNotFound();
            }
            return View(enquiry);
        }

        // POST: Enquiries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Remarks")] Enquiry enquiry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enquiry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("EnquiriesAdmin", "Home");
            }
            return View(enquiry);
        }

        // GET: Enquiries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enquiry enquiry = db.Enquiries.Find(id);
            if (enquiry == null)
            {
                return HttpNotFound();
            }
            return View(enquiry);
        }

        // POST: Enquiries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enquiry enquiry = db.Enquiries.Find(id);
            db.Enquiries.Remove(enquiry);
            db.SaveChanges();
            return RedirectToAction("EnquiriesAdmin", "Home");
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
