using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using PetProject.Models;
using System.IO;

namespace PetProject.Controllers
{
    public class Albums1Controller : Controller
    {
        private QueryContext db = new QueryContext();

        // GET: Albums1
        public ActionResult Index()
        {
            return View(db.Albums.ToList());
        }

        [HttpPost]
        public ActionResult Index(Picture picture)
        {
            /*  if (picture.pic.ContentLength > 0)
              {
                  var fileName = Path.GetFileName(picture.pic.FileName);
                  var path = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
                  picture.pic.SaveAs(path);
              }*/
            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];
                var fName = file.FileName;
                if (file != null && file.ContentLength > 0)
                {
                    var orgDirectory = new DirectoryInfo(Server.MapPath("~/Content/images"));
                    string pathString = System.IO.Path.Combine(orgDirectory.ToString(), fName);
                    var fileName1 = Path.GetFileName(file.FileName);
                   bool isExists = System.IO.Directory.Exists(orgDirectory.ToString());
                    if (!isExists)
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                    }
                    var path = string.Format(pathString, file.FileName); //pathString + file.FileName;

                    file.SaveAs(path);

                }
            }

            return RedirectToAction("Index");
        }

        // GET: Albums1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ImageFile,CreatedAt")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Albums.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(album);
        }

        // GET: Albums1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ImageFile,CreatedAt")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: Albums1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albums.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albums.Find(id);
            db.Albums.Remove(album);
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
