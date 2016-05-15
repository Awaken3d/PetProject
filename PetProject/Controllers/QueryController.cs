using PetProject.Models;

using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace PetProject.Controllers
{
    public class QueryController : Controller
    {
        private QueryContext db = new QueryContext();
       // private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Query
        public ActionResult Index()
        {
            
            using (var res = new QueryContext()) {

                // var mod = res.GetAlbums();
                /* var mod = (from row in res.Albums
                            select row).AsEnumerable();*/

                IList<result> mod = res.GetTopSongs1(DateTime.Now, DateTime.Now.AddMonths(7),10);
                //var mod = res.GetForNUsers(2);
                //Console.Out.WriteLine("dokimi");
                
                return View(mod);
            }

              
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            using (var res = new QueryContext())
            {
                decimal selection = Convert.ToDecimal(Request.Form[0]);

            string title = Request.Form[1];
            Song s = (from c in db.Songs
                      where c.Title == title
                      select c).FirstOrDefault();
            Rating rate = new Rating {
                UserId = System.Web.HttpContext.Current.User.Identity.GetUserId(),
                CreatedAt = DateTime.Now,
                RatingValue = selection,
                song = s

                };

            db.Ratings.Add(rate);
            db.SaveChanges();
                IList<result> mod = res.GetTopSongs1(DateTime.Now, DateTime.Now.AddMonths(7), 10);
                //var mod = res.GetForNUsers(2);
                //Console.Out.WriteLine("dokimi");

                return View(mod);
            }
            // var mod = res.GetAlbums();
            /* var mod = (from row in res.Albums
                        select row).AsEnumerable();*/


            //var mod = res.GetForNUsers(2);
            //Console.Out.WriteLine("dokimi");
           // return View();
                //return View(mod);
            


        }
        [HttpPost]
        public ActionResult Index2(FormCollection form1) {


            return View();

        }

        


    }
}