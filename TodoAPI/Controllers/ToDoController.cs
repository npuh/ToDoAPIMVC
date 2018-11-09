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
using TodoAPI.Models;

namespace TodoAPI.Controllers
{
    public class ToDoController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/ToDo
        public IQueryable<TDoDB> GetTDoDB()
        {
            return db.TDoDB;
        }

        // GET: api/ToDo/5
        [ResponseType(typeof(TDoDB))]
        public IHttpActionResult GetTDoDB(int id)
        {
            TDoDB tDoDB = db.TDoDB.Find(id);
            if (tDoDB == null)
            {
                return NotFound();
            }

            return Ok(tDoDB);
        }

        // PUT: api/ToDo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTDoDB(int id, TDoDB tDoDB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tDoDB.TaskId)
            {
                return BadRequest();
            }

            db.Entry(tDoDB).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TDoDBExists(id))
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

        // POST: api/ToDo
        [ResponseType(typeof(TDoDB))]
        public IHttpActionResult PostTDoDB(TDoDB tDoDB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TDoDB.Add(tDoDB);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tDoDB.TaskId }, tDoDB);
        }

        // DELETE: api/ToDo/5
        [ResponseType(typeof(TDoDB))]
        public IHttpActionResult DeleteTDoDB(int id)
        {
            TDoDB tDoDB = db.TDoDB.Find(id);
            if (tDoDB == null)
            {
                return NotFound();
            }

            db.TDoDB.Remove(tDoDB);
            db.SaveChanges();

            return Ok(tDoDB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TDoDBExists(int id)
        {
            return db.TDoDB.Count(e => e.TaskId == id) > 0;
        }
    }
}