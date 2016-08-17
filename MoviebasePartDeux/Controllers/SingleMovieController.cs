using MoviebasePartDeux.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviebasePartDeux.Controllers
{
    public class SingleMovieController : Controller
    {
        MbdbContext db = new MbdbContext();

        // GET: SingleMovie
        public ActionResult Index(string MovieName)
        {

            var Movie = db.Movies.Where(g => g.MovieName == MovieName).Select(m => m.MovieName).ToList().FirstOrDefault().ToString();

            ViewBag.MovieName = Movie;

            var MovieToList = db.Movies.Where(m => m.MovieName == MovieName).ToList();

            return View(MovieToList);
        }
    }
}