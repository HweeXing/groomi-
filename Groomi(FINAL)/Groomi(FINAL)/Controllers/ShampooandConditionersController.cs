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
    public class ShampooandConditionersController : Controller
    {
        private Model1 db = new Model1();

        // GET: ShampooandConditioners
        public ActionResult Index()
        {
            return View(db.ShampooandConditioners.ToList());
        }

        // GET: ShampooandConditioners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShampooandConditioner shampooandConditioner = db.ShampooandConditioners.Find(id);
            if (shampooandConditioner == null)
            {
                return HttpNotFound();
            }
            return View(shampooandConditioner);
        }

        // GET: ShampooandConditioners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShampooandConditioners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,Price,Name,Logo")] ShampooandConditioner shampooandConditioner)
        {
            if (ModelState.IsValid)
            {
                db.ShampooandConditioners.Add(shampooandConditioner);
                db.SaveChanges();
                return RedirectToAction("ShampooandConditionersAdmin", "Home");
            }

            return View(shampooandConditioner);
        }

        // GET: ShampooandConditioners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShampooandConditioner shampooandConditioner = db.ShampooandConditioners.Find(id);
            if (shampooandConditioner == null)
            {
                return HttpNotFound();
            }
            return View(shampooandConditioner);
        }

        // POST: ShampooandConditioners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,Price,Name,Logo")] ShampooandConditioner shampooandConditioner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shampooandConditioner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ShampooandConditionersAdmin", "Home");
            }
            return View(shampooandConditioner);
        }

        // GET: ShampooandConditioners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShampooandConditioner shampooandConditioner = db.ShampooandConditioners.Find(id);
            if (shampooandConditioner == null)
            {
                return HttpNotFound();
            }
            return View(shampooandConditioner);
        }

        // POST: ShampooandConditioners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShampooandConditioner shampooandConditioner = db.ShampooandConditioners.Find(id);
            db.ShampooandConditioners.Remove(shampooandConditioner);
            db.SaveChanges();
            return RedirectToAction("ShampooandConditionersAdmin", "Home");
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
