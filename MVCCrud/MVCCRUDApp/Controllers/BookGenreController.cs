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

        //public ActionResult LoadBookGenre() 
        //{
        //    try
        //    {
        //        using (ConnectionDb cd=new ConnectionDb())
        //        {
        //            var draw = Request.Form.GetValues("draw").FirstOrDefault();
        //            var start = Request.Form.GetValues("start").FirstOrDefault();
        //            var length = Request.Form.GetValues("length").FirstOrDefault();
        //            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
        //            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
        //            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();
        //            int pageSize = length != null ? Convert.ToInt32(length) : 0;
        //            int skip = start != null ? Convert.ToInt32(start) : 0;
        //            int recordTotal = 0;
        //            var bookGenreData = (from tempGenre in cd.BookGenre select tempGenre);

        //            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
        //            {
        //                bookGenreData = bookGenreData.OrderBy(sortColumn + " " + sortColumnDir);
        //            }

        //            if (!string.IsNullOrEmpty(searchValue))
        //            {
        //                bookGenreData = bookGenreData.Where(m => m.BookGenreName == searchValue);
        //            }

        //            recordTotal = bookGenreData.Count();
        //            var data = bookGenreData.Skip(skip).Take(pageSize).ToList();
        //            return Json(new { draw = draw, recordsFiltered = recordTotal, recordsTotal = recordTotal, data = data });

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        // }








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