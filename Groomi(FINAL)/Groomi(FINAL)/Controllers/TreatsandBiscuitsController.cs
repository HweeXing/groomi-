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
    public class TreatsandBiscuitsController : Controller
    {
        private Model1 db = new Model1();

        // GET: TreatsandBiscuits
        public ActionResult Index()
        {
            return View(db.TreatsandBiscuits.ToList());
        }

        // GET: TreatsandBiscuits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatsandBiscuit treatsandBiscuit = db.TreatsandBiscuits.Find(id);
            if (treatsandBiscuit == null)
            {
                return HttpNotFound();
            }
            return View(treatsandBiscuit);
        }

        // GET: TreatsandBiscuits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TreatsandBiscuits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,Price,Name,Logo")] TreatsandBiscuit treatsandBiscuit)
        {
            if (ModelState.IsValid)
            {
                db.TreatsandBiscuits.Add(treatsandBiscuit);
                db.SaveChanges();
                return RedirectToAction("TreatsandBiscuitsAdmin", "Home");
            }

            return View(treatsandBiscuit);
        }

        // GET: TreatsandBiscuits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatsandBiscuit treatsandBiscuit = db.TreatsandBiscuits.Find(id);
            if (treatsandBiscuit == null)
            {
                return HttpNotFound();
            }
            return View(treatsandBiscuit);
        }

        // POST: TreatsandBiscuits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,Price,Name,Logo")] TreatsandBiscuit treatsandBiscuit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatsandBiscuit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TreatsandBiscuitsAdmin", "Home");
            }
            return View(treatsandBiscuit);
        }

        // GET: TreatsandBiscuits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatsandBiscuit treatsandBiscuit = db.TreatsandBiscuits.Find(id);
            if (treatsandBiscuit == null)
            {
                return HttpNotFound();
            }
            return View(treatsandBiscuit);
        }

        // POST: TreatsandBiscuits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TreatsandBiscuit treatsandBiscuit = db.TreatsandBiscuits.Find(id);
            db.TreatsandBiscuits.Remove(treatsandBiscuit);
            db.SaveChanges();
            return RedirectToAction("TreatsandBiscuitsAdmin", "Home");
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
