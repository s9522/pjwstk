using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pjatk.Pab.Books.Domain.Models;
using Pjatk.Pab.Books.BLL.Interfaces;


namespace Web.Controllers
{
    public class AuthorsController : Controller
    {
        IAuthors _authorsFacade;

        public AuthorsController(IAuthors authorsFacade)
        {
            _authorsFacade = authorsFacade;
        }

        // GET: Authors
        public ActionResult Index()
        {
            return View(_authorsFacade.GetAllAuthors());
        }

        // GET: Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = _authorsFacade.GetAuthorById(id.Value);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,DateOfBirth")] Author author)
        {
            if (ModelState.IsValid)
            {
                _authorsFacade.CreateAuthor(author);
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = _authorsFacade.GetAuthorById(id.Value);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,DateOfBirth")] Author author)
        {
            if (ModelState.IsValid)
            {
                _authorsFacade.UpdateAuthor(author);
                
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = _authorsFacade.GetAuthorById(id.Value);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _authorsFacade.RemoveAuthor(id);
            return RedirectToAction("Index");
        }
    }
}
