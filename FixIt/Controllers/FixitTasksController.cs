using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FixIt.Models;
using FixitRepository;

namespace FixIt.Controllers
{
    public class FixitTasksController : Controller
    {
        private FixItContext db = new FixItContext();

        // GET: FixitTasks
        public async Task<ActionResult> Index()
        {
            return View(await db.FixitTasks.ToListAsync());
        }

        // GET: FixitTasks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FixitTask fixitTask = await db.FixitTasks.FindAsync(id);
            if (fixitTask == null)
            {
                return HttpNotFound();
            }
            return View(fixitTask);
        }

        // GET: FixitTasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FixitTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CreatedBy,Title,Notes,IsDone")] FixitTask fixitTask, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                string url = null;

                if (photo != null)
                {
                    PhotoService service = new PhotoService();
                    url = await service.UploadFotoAsync(photo);
                    fixitTask.PhotoUrl = url;
                }
                
                db.FixitTasks.Add(fixitTask);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(fixitTask);
        }

        // GET: FixitTasks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FixitTask fixitTask = await db.FixitTasks.FindAsync(id);
            if (fixitTask == null)
            {
                return HttpNotFound();
            }
            return View(fixitTask);
        }

        // POST: FixitTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CreatedBy,Title,Notes,PhotoUrl,IsDone")] FixitTask fixitTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fixitTask).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fixitTask);
        }

        // GET: FixitTasks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FixitTask fixitTask = await db.FixitTasks.FindAsync(id);
            if (fixitTask == null)
            {
                return HttpNotFound();
            }
            return View(fixitTask);
        }

        // POST: FixitTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FixitTask fixitTask = await db.FixitTasks.FindAsync(id);
            db.FixitTasks.Remove(fixitTask);
            await db.SaveChangesAsync();
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
