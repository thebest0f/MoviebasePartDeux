using MoviebasePartDeux.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviebasePartDeux.Controllers
{
    public class FullMovieListController : Controller
    {


        private MbdbContext db = new MbdbContext();
        // GET: FullMovieList
        public ActionResult Index(int Genre)
        {

            var gId = db.Genres.Where(g => g.GenreId == Genre).Select(g=>g.GenreName).ToList().FirstOrDefault().ToString();

            ViewBag.GenreId = gId;

            var movieList = db.Movies.Where(m => m.GenreRefId == Genre).OrderBy(m => m.MovieName).ToList();

            return View(movieList);
        }
    }
}