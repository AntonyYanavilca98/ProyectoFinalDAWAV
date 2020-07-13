using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class SalesInvocesController : ApiController
    {
        private ProyectoFinalContext db = new ProyectoFinalContext();

        // GET: api/SalesInvoces
        public IQueryable<SalesInvoce> GetSalesInvoces()
        {
            return db.SalesInvoces;
        }

        // GET: api/SalesInvoces/5
        [ResponseType(typeof(SalesInvoce))]
        public async Task<IHttpActionResult> GetSalesInvoce(int id)
        {
            SalesInvoce salesInvoce = await db.SalesInvoces.FindAsync(id);
            if (salesInvoce == null)
            {
                return NotFound();
            }

            return Ok(salesInvoce);
        }

        // PUT: api/SalesInvoces/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSalesInvoce(int id, SalesInvoce salesInvoce)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salesInvoce.SalesInvoceID)
            {
                return BadRequest();
            }

            db.Entry(salesInvoce).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesInvoceExists(id))
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

        // POST: api/SalesInvoces
        [ResponseType(typeof(SalesInvoce))]
        public async Task<IHttpActionResult> PostSalesInvoce(SalesInvoce salesInvoce)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SalesInvoces.Add(salesInvoce);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = salesInvoce.SalesInvoceID }, salesInvoce);
        }

        // DELETE: api/SalesInvoces/5
        [ResponseType(typeof(SalesInvoce))]
        public async Task<IHttpActionResult> DeleteSalesInvoce(int id)
        {
            SalesInvoce salesInvoce = await db.SalesInvoces.FindAsync(id);
            if (salesInvoce == null)
            {
                return NotFound();
            }

            db.SalesInvoces.Remove(salesInvoce);
            await db.SaveChangesAsync();

            return Ok(salesInvoce);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesInvoceExists(int id)
        {
            return db.SalesInvoces.Count(e => e.SalesInvoceID == id) > 0;
        }
    }
}