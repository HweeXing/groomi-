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
    public class GroomingToolsController : Controller
    {
        private Model1 db = new Model1();

        // GET: GroomingTools
        public ActionResult Index()
        {
            return View(db.GroomingTools.ToList());
        }

        // GET: GroomingTools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroomingTool groomingTool = db.GroomingTools.Find(id);
            if (groomingTool == null)
            {
                return HttpNotFound();
            }
            return View(groomingTool);
        }

        // GET: GroomingTools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroomingTools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,Price,Name,Logo")] GroomingTool groomingTool)
        {
            if (ModelState.IsValid)
            {
                db.GroomingTools.Add(groomingTool);
                db.SaveChanges();
                return RedirectToAction("GroomingToolsAdmin", "Home");
            }

            return View(groomingTool);
        }

        // GET: GroomingTools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroomingTool groomingTool = db.GroomingTools.Find(id);
            if (groomingTool == null)
            {
                return HttpNotFound();
            }
            return View(groomingTool);
        }

        // POST: GroomingTools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,Price,Name,Logo")] GroomingTool groomingTool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groomingTool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GroomingToolsAdmin", "Home");
            }
            return View(groomingTool);
        }

        // GET: GroomingTools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroomingTool groomingTool = db.GroomingTools.Find(id);
            if (groomingTool == null)
            {
                return HttpNotFound();
            }
            return View(groomingTool);
        }

        // POST: GroomingTools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroomingTool groomingTool = db.GroomingTools.Find(id);
            db.GroomingTools.Remove(groomingTool);
            db.SaveChanges();
            return RedirectToAction("GroomingToolsAdmin", "Home");
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
