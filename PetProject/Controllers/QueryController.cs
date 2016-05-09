using PetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetProject.Controllers
{
    public class QueryController : Controller
    {
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
    }
}