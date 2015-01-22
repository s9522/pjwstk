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
    public class BooksController : Controller
    {
        IBooks _booksFacade;
        IAuthors _authorsFacade;

        public BooksController(IBooks booksFacade, IAuthors authorsFacade)
        {
            _booksFacade = booksFacade;
            _authorsFacade = authorsFacade;
        }

        // GET: Books
        public ActionResult Index()
        {
            return View(_booksFacade.GetAllBooks());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _booksFacade.GetBookById(id.Value);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewData["authors"] = _authorsFacade.GetAllAuthors().ToList();
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Subtitle,Isbn,Publisher,PublishDate,PagesCount,EditionNumber")] Book book, string[] authorsIds)
        {
            if (ModelState.IsValid)
            {
                if (authorsIds!=null)
                {
                    book.Authors = new List<Author>();
                    foreach (var item in authorsIds)
                    {
                        var author = _authorsFacade.GetAuthorById(int.Parse(item));
                        book.Authors.Add(author);
                    }
                }
                _booksFacade.CreateBook(book);
                
                return RedirectToAction("Index");
            }
            ViewData["authors"] = _authorsFacade.GetAllAuthors().ToList();
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _booksFacade.GetBookById(id.Value);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Subtitle,Isbn,Publisher,PublishDate,PagesCount,EditionNumber")] Book book)
        {
            if (ModelState.IsValid)
            {
                _booksFacade.UpdateBook(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _booksFacade.GetBookById(id.Value);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _booksFacade.RemoveBook(id);
            return RedirectToAction("Index");
        }
    }
}
