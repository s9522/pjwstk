using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pjatk.Pab.Books.BLL.Facades;
namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Books()
        {
            return RedirectToAction("Index", "Books");
        }

        public ActionResult Authors()
        {
            return RedirectToAction("Index", "Authors");
        }
    }
}