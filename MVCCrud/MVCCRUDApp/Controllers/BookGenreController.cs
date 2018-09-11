using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCRUDApp.Models;
using System.Data.Entity;
using System.Linq.Dynamic;

namespace MVCCRUDApp.Controllers
{
    public class BookGenreController : Controller
    {
        private ConnectionDb db=new ConnectionDb();
        public ActionResult ViewBookGenre()
        {
            var bookGenreData = (from tempGenre in db.BookGenre select tempGenre);
            return View(bookGenreData.ToList());
        }
        
        [HttpGet]
        public ActionResult AddBookGenre()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBookGenre(BookGenre bookGenre)
        {
            if (ModelState.IsValid)
            {
                db.BookGenre.Add(bookGenre);
                db.SaveChanges();
            }
            return RedirectToAction("ViewBookGenre");
        }

        public JsonResult IsBookGenreNameExists(string bookGenreName)
        {
            return Json(!db.BookGenre.Any(b=>b.BookGenreName== bookGenreName),JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditBookGenre(int? id)
        {
            BookGenre bookGenre = db.BookGenre.Find(id);

            return PartialView(bookGenre);
        }
        [HttpPost]
        public ActionResult EditBookGenre(BookGenre bookGenre, int? id)
        {
            if (ModelState.IsValid)
            {

                db.Entry(bookGenre).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("ViewBookGenre");
        }

        public ActionResult Delete(int id)
        {
            db.BookGenre.Remove(db.BookGenre.Find(id));
            db.SaveChanges();
            return RedirectToAction("ViewBookGenre");
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