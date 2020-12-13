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
using LabDay2API.Models;

namespace LabDay2API.Controllers
{
    public class TbNewsController : ApiController
    {
        private ITIContext db = new ITIContext();

        // GET: api/TbNews
        public IQueryable<TbNew> GetTbNews()
        {
            return db.TbNews;
        }

        // GET: api/TbNews/5
        [ResponseType(typeof(TbNew))]
        public IHttpActionResult GetTbNew(int id)
        {
            TbNew tbNew = db.TbNews.Find(id);
            if (tbNew == null)
            {
                return NotFound();
            }

            return Ok(tbNew);
        }

        // PUT: api/TbNews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbNew(int id, TbNew tbNew)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbNew.id)
            {
                return BadRequest();
            }

            db.Entry(tbNew).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbNewExists(id))
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

        // POST: api/TbNews
        [ResponseType(typeof(TbNew))]
        public IHttpActionResult PostTbNew(TbNew tbNew)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TbNews.Add(tbNew);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbNew.id }, tbNew);
        }

        // DELETE: api/TbNews/5
        [ResponseType(typeof(TbNew))]
        public IHttpActionResult DeleteTbNew(int id)
        {
            TbNew tbNew = db.TbNews.Find(id);
            if (tbNew == null)
            {
                return NotFound();
            }

            db.TbNews.Remove(tbNew);
            db.SaveChanges();

            return Ok(tbNew);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TbNewExists(int id)
        {
            return db.TbNews.Count(e => e.id == id) > 0;
        }
    }
}