using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Pjatk.Pab.Books.BLL.Interfaces;
using Pjatk.Pab.Books.Domain.Models;

namespace Web.Controllers
{
    public class BookRentalsController : Controller
    {
        private readonly IReaders _readers;
        private readonly IBooks _books;
        private readonly IBookRentals _bookRentals;

        public BookRentalsController(IReaders readers, IBooks books, IBookRentals bookRentals)
        {
            _readers = readers;
            _books = books;
            _bookRentals = bookRentals;
        }

        // GET: BookRentals
        public ActionResult Index()
        {
            return View(_bookRentals.GetAllBookRentals().ToList());
        }

        // GET: BookRentals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookRental bookRental = _bookRentals.GetBookRentalById(id.Value);
            if (bookRental == null)
            {
                return HttpNotFound();
            }
            return View(bookRental);
        }

        // GET: BookRentals/Create
        public ActionResult Create()
        {
            ViewData["books"] = _books.GetAllBooks().ToList();
            ViewData["readers"] = _readers.GetAllReaders().ToList();
            return View();
        }

        // POST: BookRentals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateFrom,DateTo")] BookRental bookRental, string readerId,
            string[] booksIds)
        {
            BookRental rental = bookRental;
            if (ModelState.IsValid)
            {
                if (booksIds != null && readerId != null)
                {
                    rental.Books = new List<Book>();
                    foreach (var item in booksIds)
                    {
                        var book = _books.GetBookById(int.Parse(item));
                        rental.Books.Add(book);
                    }
                    rental.Reader = _readers.GetReaderById(int.Parse(readerId)); 
                    _bookRentals.CreateBookRental(rental);
                    return RedirectToAction("Index");
                }
            }
            return View(rental);
        }
       

        // GET: BookRentals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookRental bookRental = _bookRentals.GetBookRentalById(id.Value);
            if (bookRental == null)
            {
                return HttpNotFound();
            }
            return View(bookRental);
        }

        // POST: BookRentals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateFrom,DateTo")] BookRental bookRental)
        {
            if (ModelState.IsValid)
            {
                _bookRentals.UpdateBookRental(bookRental);
                return RedirectToAction("Index");
            }
            return View(bookRental);
        }

        // GET: BookRentals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookRental bookRental = _bookRentals.GetBookRentalById(id.Value);
            if (bookRental == null)
            {
                return HttpNotFound();
            }
            return View(bookRental);
        }

        // POST: BookRentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookRental bookRental = _bookRentals.GetBookRentalById(id);
            _bookRentals.RemoveBookRental(bookRental);
            return RedirectToAction("Index");
        }
    }
}
