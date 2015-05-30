using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Groomi_FINAL_.Models;

namespace Groomi_FINAL_.Controllers
{
    public class TreatsandBiscuitsAPIController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/TreatsandBiscuitsAPI
        public IQueryable<TreatsandBiscuit> GetTreatsandBiscuits()
        {
            return db.TreatsandBiscuits;
        }

        // GET: api/TreatsandBiscuitsAPI/5
        [ResponseType(typeof(TreatsandBiscuit))]
        public IHttpActionResult GetTreatsandBiscuit(int id)
        {
            TreatsandBiscuit treatsandBiscuit = db.TreatsandBiscuits.Find(id);
            if (treatsandBiscuit == null)
            {
                return NotFound();
            }

            return Ok(treatsandBiscuit);
        }

        // PUT: api/TreatsandBiscuitsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTreatsandBiscuit(int id, TreatsandBiscuit treatsandBiscuit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != treatsandBiscuit.ID)
            {
                return BadRequest();
            }

            db.Entry(treatsandBiscuit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreatsandBiscuitExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TreatsandBiscuitsAPI
        [ResponseType(typeof(TreatsandBiscuit))]
        public IHttpActionResult PostTreatsandBiscuit(TreatsandBiscuit treatsandBiscuit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TreatsandBiscuits.Add(treatsandBiscuit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = treatsandBiscuit.ID }, treatsandBiscuit);
        }

        // DELETE: api/TreatsandBiscuitsAPI/5
        [ResponseType(typeof(TreatsandBiscuit))]
        public IHttpActionResult DeleteTreatsandBiscuit(int id)
        {
            TreatsandBiscuit treatsandBiscuit = db.TreatsandBiscuits.Find(id);
            if (treatsandBiscuit == null)
            {
                return NotFound();
            }

            db.TreatsandBiscuits.Remove(treatsandBiscuit);
            db.SaveChanges();

            return Ok(treatsandBiscuit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TreatsandBiscuitExists(int id)
        {
            return db.TreatsandBiscuits.Count(e => e.ID == id) > 0;
        }
    }
}