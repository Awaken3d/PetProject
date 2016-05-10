using PetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetProject.Controllers
{
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index()
        {
            using (var res = new QueryContext())
            {
                IList<result> mod = res.GetTopSongs1(DateTime.Now, DateTime.Now.AddMonths(7), 10);
                return View(mod);
            }
        }
    }
}