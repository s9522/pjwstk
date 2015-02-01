using System.Linq;
using System.Net;
using System.Web.Mvc;
using Pjatk.Pab.Books.BLL.Interfaces;
using Pjatk.Pab.Books.Domain.Models;

namespace Web.Controllers
{
    public class ReadersController : Controller
    {
        private readonly IReaders _readers;

        public ReadersController(IReaders readers)
        {
            _readers = readers;
        }

        // GET: Readers
        public ActionResult Index()
        {
            return View(_readers.GetAllReaders().ToList());
        }

        // GET: Readers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reader reader = _readers.GetReaderById(id.Value);
            if (reader == null)
            {
                return HttpNotFound();
            }
            return View(reader);
        }

        // GET: Readers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Readers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName")] Reader reader)
        {
            if (ModelState.IsValid)
            {
                _readers.CreateReader(reader);
                return RedirectToAction("Index");
            }

            return View(reader);
        }

        // GET: Readers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reader reader = _readers.GetReaderById(id.Value);
            if (reader == null)
            {
                return HttpNotFound();
            }
            return View(reader);
        }

        // POST: Readers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName")] Reader reader)
        {
            if (ModelState.IsValid)
            {
                _readers.UpdateReader(reader);
                return RedirectToAction("Index");
            }
            return View(reader);
        }

        // GET: Readers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reader reader = _readers.GetReaderById(id.Value);
            if (reader == null)
            {
                return HttpNotFound();
            }
            return View(reader);
        }

        // POST: Readers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reader reader = _readers.GetReaderById(id);
            _readers.RemoveReader(reader);
            return RedirectToAction("Index");
        }
    }
}
