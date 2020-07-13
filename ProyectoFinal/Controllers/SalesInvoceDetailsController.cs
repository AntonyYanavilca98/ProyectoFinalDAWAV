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
    public class SalesInvoceDetailsController : ApiController
    {
        private ProyectoFinalContext db = new ProyectoFinalContext();

        // GET: api/SalesInvoceDetails
        public IQueryable<SalesInvoceDetail> GetSalesInvoceDetails()
        {
            return db.SalesInvoceDetails;
        }

        // GET: api/SalesInvoceDetails/5
        [ResponseType(typeof(SalesInvoceDetail))]
        public async Task<IHttpActionResult> GetSalesInvoceDetail(int id)
        {
            SalesInvoceDetail salesInvoceDetail = await db.SalesInvoceDetails.FindAsync(id);
            if (salesInvoceDetail == null)
            {
                return NotFound();
            }

            return Ok(salesInvoceDetail);
        }

        // PUT: api/SalesInvoceDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSalesInvoceDetail(int id, SalesInvoceDetail salesInvoceDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salesInvoceDetail.SalesInvoceDetailID)
            {
                return BadRequest();
            }

            db.Entry(salesInvoceDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesInvoceDetailExists(id))
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

        // POST: api/SalesInvoceDetails
        [ResponseType(typeof(SalesInvoceDetail))]
        public async Task<IHttpActionResult> PostSalesInvoceDetail(SalesInvoceDetail salesInvoceDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SalesInvoceDetails.Add(salesInvoceDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = salesInvoceDetail.SalesInvoceDetailID }, salesInvoceDetail);
        }

        // DELETE: api/SalesInvoceDetails/5
        [ResponseType(typeof(SalesInvoceDetail))]
        public async Task<IHttpActionResult> DeleteSalesInvoceDetail(int id)
        {
            SalesInvoceDetail salesInvoceDetail = await db.SalesInvoceDetails.FindAsync(id);
            if (salesInvoceDetail == null)
            {
                return NotFound();
            }

            db.SalesInvoceDetails.Remove(salesInvoceDetail);
            await db.SaveChangesAsync();

            return Ok(salesInvoceDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesInvoceDetailExists(int id)
        {
            return db.SalesInvoceDetails.Count(e => e.SalesInvoceDetailID == id) > 0;
        }
    }
}