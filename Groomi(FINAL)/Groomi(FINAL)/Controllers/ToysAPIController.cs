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
    public class ToysAPIController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/ToysAPI
        public IQueryable<Toy> GetToys()
        {
            return db.Toys;
        }

        // GET: api/ToysAPI/5
        [ResponseType(typeof(Toy))]
        public IHttpActionResult GetToy(int id)
        {
            Toy toy = db.Toys.Find(id);
            if (toy == null)
            {
                return NotFound();
            }

            return Ok(toy);
        }

        // PUT: api/ToysAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutToy(int id, Toy toy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toy.ID)
            {
                return BadRequest();
            }

            db.Entry(toy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToyExists(id))
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

        // POST: api/ToysAPI
        [ResponseType(typeof(Toy))]
        public IHttpActionResult PostToy(Toy toy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Toys.Add(toy);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = toy.ID }, toy);
        }

        // DELETE: api/ToysAPI/5
        [ResponseType(typeof(Toy))]
        public IHttpActionResult DeleteToy(int id)
        {
            Toy toy = db.Toys.Find(id);
            if (toy == null)
            {
                return NotFound();
            }

            db.Toys.Remove(toy);
            db.SaveChanges();

            return Ok(toy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToyExists(int id)
        {
            return db.Toys.Count(e => e.ID == id) > 0;
        }
    }
}