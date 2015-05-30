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
    public class ShampooandConditionersAPIController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/ShampooandConditionersAPI
        public IQueryable<ShampooandConditioner> GetShampooandConditioners()
        {
            return db.ShampooandConditioners;
        }

        // GET: api/ShampooandConditionersAPI/5
        [ResponseType(typeof(ShampooandConditioner))]
        public IHttpActionResult GetShampooandConditioner(int id)
        {
            ShampooandConditioner shampooandConditioner = db.ShampooandConditioners.Find(id);
            if (shampooandConditioner == null)
            {
                return NotFound();
            }

            return Ok(shampooandConditioner);
        }

        // PUT: api/ShampooandConditionersAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShampooandConditioner(int id, ShampooandConditioner shampooandConditioner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shampooandConditioner.ID)
            {
                return BadRequest();
            }

            db.Entry(shampooandConditioner).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShampooandConditionerExists(id))
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

        // POST: api/ShampooandConditionersAPI
        [ResponseType(typeof(ShampooandConditioner))]
        public IHttpActionResult PostShampooandConditioner(ShampooandConditioner shampooandConditioner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShampooandConditioners.Add(shampooandConditioner);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shampooandConditioner.ID }, shampooandConditioner);
        }

        // DELETE: api/ShampooandConditionersAPI/5
        [ResponseType(typeof(ShampooandConditioner))]
        public IHttpActionResult DeleteShampooandConditioner(int id)
        {
            ShampooandConditioner shampooandConditioner = db.ShampooandConditioners.Find(id);
            if (shampooandConditioner == null)
            {
                return NotFound();
            }

            db.ShampooandConditioners.Remove(shampooandConditioner);
            db.SaveChanges();

            return Ok(shampooandConditioner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShampooandConditionerExists(int id)
        {
            return db.ShampooandConditioners.Count(e => e.ID == id) > 0;
        }
    }
}