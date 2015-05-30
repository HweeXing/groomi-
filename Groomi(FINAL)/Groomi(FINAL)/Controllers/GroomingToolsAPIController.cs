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
    public class GroomingToolsAPIController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/GroomingToolsAPI
        public IQueryable<GroomingTool> GetGroomingTools()
        {
            return db.GroomingTools;
        }

        // GET: api/GroomingToolsAPI/5
        [ResponseType(typeof(GroomingTool))]
        public IHttpActionResult GetGroomingTool(int id)
        {
            GroomingTool groomingTool = db.GroomingTools.Find(id);
            if (groomingTool == null)
            {
                return NotFound();
            }

            return Ok(groomingTool);
        }

        // PUT: api/GroomingToolsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroomingTool(int id, GroomingTool groomingTool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groomingTool.ID)
            {
                return BadRequest();
            }

            db.Entry(groomingTool).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroomingToolExists(id))
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

        // POST: api/GroomingToolsAPI
        [ResponseType(typeof(GroomingTool))]
        public IHttpActionResult PostGroomingTool(GroomingTool groomingTool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GroomingTools.Add(groomingTool);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = groomingTool.ID }, groomingTool);
        }

        // DELETE: api/GroomingToolsAPI/5
        [ResponseType(typeof(GroomingTool))]
        public IHttpActionResult DeleteGroomingTool(int id)
        {
            GroomingTool groomingTool = db.GroomingTools.Find(id);
            if (groomingTool == null)
            {
                return NotFound();
            }

            db.GroomingTools.Remove(groomingTool);
            db.SaveChanges();

            return Ok(groomingTool);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroomingToolExists(int id)
        {
            return db.GroomingTools.Count(e => e.ID == id) > 0;
        }
    }
}