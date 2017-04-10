using HappyLifeManagement.Data;
using HappyLifeManagement.Data.Entity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using HappyLifeManagement.Helper;

namespace HappyLifeManagement.Controllers
{
    public class NotesController : Controller
    {
        private HappyLifeManagementContext db = new HappyLifeManagementContext();

        // GET: Notes
        public ActionResult Index(int? page)
        {
            //WriteLog.LogInfo("***** Debug Notes Controller *****");

            int pageSize = 2;
            int pageNumber = (page ?? 1);
            return View(db.Notes.OrderByDescending(i => i.UpdatedDate).ToPagedList(pageNumber, pageSize));
        }

        // GET: Notes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // GET: Notes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                note.Id = Guid.NewGuid();

                DateTime currentDate = DateTime.Now;
                note.CreatedDate = currentDate;
                note.UpdatedDate = currentDate;

                db.Notes.Add(note);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(note);
        }

        // GET: Notes/Edit/5
        [ValidateInput(false)]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Note note)
        {
            if (ModelState.IsValid)
            {
                var findNote = db.Notes.FirstOrDefault(i => i.Id == note.Id);

                if (findNote != null)
                {
                    findNote.UpdatedDate = DateTime.Now;
                    findNote.Title = note.Title;
                    findNote.Content = note.Content;
                    findNote.Tags = note.Tags;

                    db.Entry(findNote).State = EntityState.Modified;
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }
            return View(note);
        }

        // GET: Notes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Note note = db.Notes.Find(id);
            db.Notes.Remove(note);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
