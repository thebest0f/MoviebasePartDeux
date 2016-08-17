using MoviebasePartDeux.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviebasePartDeux.Controllers
{
    public class AutoCompleteController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            MbdbContext db = new MbdbContext();

            return View(db.Movies.ToList());
        }


        [HttpPost]
        public JsonResult GetMovieTitles(string term)
        {
            MbdbContext db = new MbdbContext();

            List<string> MovieTitleList = new List<string>();

            //foreach (var item in db.Movies.Where(m => m.MovieName.Contains(movie_name)).ToList())
            //{
            //    MovieTitleList.Add(item.MovieName);
            //}

            var MName = (from N in db.Movies
                         where N.MovieName.ToLower().Contains(term.ToLower())
                         select new { N.MovieName }).Distinct();

            return Json(MName, JsonRequestBehavior.AllowGet);
        }
    }
}