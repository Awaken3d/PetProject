using PetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetProject.Controllers
{
    public class TrendsController : Controller
    {
        // GET: Trends
        public ActionResult Index(string songName)
        {
            using (var res = new QueryContext())
            {
                int id = res.getSongId(songName);
                List<resultAverage> mod = res.GetAverageHistory(id);

                return View(mod);

            }
              
        }

       
    }
}