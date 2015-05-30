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
    public class EnquiriesAPIController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/EnquiriesAPI
        public IQueryable<Enquiry> GetEnquiries()
        {
            return db.Enquiries;
        }

        // GET: api/EnquiriesAPI/5
        [ResponseType(typeof(Enquiry))]
        public IHttpActionResult GetEnquiry(int id)
        {
            Enquiry enquiry = db.Enquiries.Find(id);
            if (enquiry == null)
            {
                return NotFound();
            }

            return Ok(enquiry);
        }

        // PUT: api/EnquiriesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEnquiry(int id, Enquiry enquiry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != enquiry.ID)
            {
                return BadRequest();
            }

            db.Entry(enquiry).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnquiryExists(id))
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

        // POST: api/EnquiriesAPI
        [ResponseType(typeof(Enquiry))]
        public IHttpActionResult PostEnquiry(Enquiry enquiry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Enquiries.Add(enquiry);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = enquiry.ID }, enquiry);
        }

        // DELETE: api/EnquiriesAPI/5
        [ResponseType(typeof(Enquiry))]
        public IHttpActionResult DeleteEnquiry(int id)
        {
            Enquiry enquiry = db.Enquiries.Find(id);
            if (enquiry == null)
            {
                return NotFound();
            }

            db.Enquiries.Remove(enquiry);
            db.SaveChanges();

            return Ok(enquiry);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnquiryExists(int id)
        {
            return db.Enquiries.Count(e => e.ID == id) > 0;
        }
    }
}