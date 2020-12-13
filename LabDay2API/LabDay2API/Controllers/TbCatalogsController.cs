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
    public class TbCatalogsController : ApiController
    {
        private ITIContext db = new ITIContext();

        // GET: api/TbCatalogs
        public IQueryable<TbCatalog> GetTbCatalogs()
        {
            return db.TbCatalogs;
        }

        // GET: api/TbCatalogs/5
        [ResponseType(typeof(TbCatalog))]
        public IHttpActionResult GetTbCatalog(int id)
        {
            TbCatalog tbCatalog = db.TbCatalogs.Find(id);
            if (tbCatalog == null)
            {
                return NotFound();
            }

            return Ok(tbCatalog);
        }
        public IHttpActionResult GetbyName(string name)
        {
            TbCatalog tbCatalog = db.TbCatalogs.Where(n=>n.name==name).FirstOrDefault();
            if (tbCatalog == null)
            {
                return NotFound();
            }

            return Ok(tbCatalog);
        }

        // PUT: api/TbCatalogs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbCatalog(int id, TbCatalog tbCatalog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbCatalog.id)
            {
                return BadRequest();
            }

            db.Entry(tbCatalog).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbCatalogExists(id))
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

        // POST: api/TbCatalogs
        [ResponseType(typeof(TbCatalog))]
        public IHttpActionResult PostTbCatalog(TbCatalog tbCatalog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TbCatalogs.Add(tbCatalog);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TbCatalogExists(tbCatalog.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbCatalog.id }, tbCatalog);
        }

        // DELETE: api/TbCatalogs/5
        [ResponseType(typeof(TbCatalog))]
        public IHttpActionResult DeleteTbCatalog(int id)
        {
            TbCatalog tbCatalog = db.TbCatalogs.Find(id);
            if (tbCatalog == null)
            {
                return NotFound();
            }

            db.TbCatalogs.Remove(tbCatalog);
            db.SaveChanges();

            return Ok(tbCatalog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TbCatalogExists(int id)
        {
            return db.TbCatalogs.Count(e => e.id == id) > 0;
        }
    }
}