using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq.Dynamic;
using MVCCRUDApp.Models;

namespace MVCCRUDApp.Controllers
{
    public class BookController : Controller
    {
        private ConnectionDb db = new ConnectionDb();

        public ActionResult ViewBook()
        {
            var bookData = (from b in db.Book select b);
            return View(bookData.ToList());
        }

        public JsonResult LoadBook()
        {
            try
            {
                using (ConnectionDb cd=new ConnectionDb())
                {
                    var draw = Request.Form.GetValues("draw").FirstOrDefault();
                    var start = Request.Form.GetValues("start").FirstOrDefault();
                    var length = Request.Form.GetValues("length").FirstOrDefault();
                    var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                    var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                    var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();
                    int pageSize = length != null ? Convert.ToInt32(length) : 0;
                    int skip = start != null ? Convert.ToInt32(start) : 0;
                    int recordTotal = 0;

                    var bookData = (from b in db.Book select b);


                    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                    {
                        bookData = bookData.OrderBy(sortColumn + " " + sortColumnDir);
                    }

                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        bookData = bookData.Where(m => m.BookName == searchValue);
                    }

                    recordTotal = bookData.Count();
                    var data = bookData.Skip(skip).Take(pageSize).ToList();
                    return Json(new { draw = draw, recordsFiltered = recordTotal, recordsTotal = recordTotal, data = data });

                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            ViewBag.BookGenreId = new SelectList(db.BookGenre, "BookGenreId", "BookGenreName");
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Book.Add(book);
                db.SaveChanges();
            }
            ViewBag.BookGenreId = new SelectList(db.BookGenre, "BookGenreId", "BookGenreName",book.BookGenreId);
            return RedirectToAction("ViewBook");
        }


        public ActionResult EditBook(int? id)
        {
            Book book = db.Book.Find(id);
            ViewBag.BookGenreId = new SelectList(db.BookGenre, "BookGenreId", "BookGenreName", book.BookGenreId);
            return PartialView(book);
        }
        [HttpPost]
        public ActionResult EditBook(Book book, int? id)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
            }
            ViewBag.BookGenreId = new SelectList(db.BookGenre, "BookGenreId", "BookGenreName", book.BookGenreId);
            return RedirectToAction("ViewBook");
        }

        public ActionResult Delete(int id)
        {
            db.Book.Remove(db.Book.Find(id));
            db.SaveChanges();
            return RedirectToAction("ViewBook");
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