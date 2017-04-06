using HappyLifeManagement.Data;
using HappyLifeManagement.Data.Entity;
using KT.Core;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace HappyLifeManagement.Controllers.API
{
    [RoutePrefix("api/notes")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class NotesController : ApiController
    {
        private HappyLifeManagementContext database = new HappyLifeManagementContext();

        // GET: api/Notes
        public IHttpActionResult GetNotes(int? page=1)
        {
            int pageSie = 2;

            var data = new KTPagedList<Note>(database.Notes.OrderByDescending(i => i.UpdatedDate), page, pageSie);

            return Ok(data);
        }

        // GET: api/Notes/5
        [ResponseType(typeof(Note))]
        public IHttpActionResult GetNote(Guid id)
        {
            Note note = database.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        // PUT: api/Notes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNote(Guid id, Note note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != note.Id)
            {
                return BadRequest();
            }

            database.Entry(note).State = EntityState.Modified;

            try
            {
                database.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
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

        // POST: api/Notes
        [ResponseType(typeof(Note))]
        public IHttpActionResult PostNote(Note note)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            database.Notes.Add(note);

            try
            {
                database.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (NoteExists(note.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = note.Id }, note);
        }

        // DELETE: api/Notes/5
        [ResponseType(typeof(Note))]
        public IHttpActionResult DeleteNote(Guid id)
        {
            Note note = database.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }

            database.Notes.Remove(note);
            database.SaveChanges();

            return Ok(note);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                database.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NoteExists(Guid id)
        {
            return database.Notes.Count(e => e.Id == id) > 0;
        }
    }
}