using PetProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetProject.Controllers
{
    public class AlbumsController : Controller
    {
        // GET: Album
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Picture picture)
        {
            if(picture.pic.ContentLength > 0) { 
            var fileName = Path.GetFileName(picture.pic.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
            picture.pic.SaveAs(path);
            }

            return RedirectToAction("Index");
        }
    }
}