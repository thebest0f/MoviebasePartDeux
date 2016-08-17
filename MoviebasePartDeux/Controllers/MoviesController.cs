using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviebasePartDeux.Models;

namespace MoviebasePartDeux.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class MoviesController : Controller
    {
        private MbdbContext db = new MbdbContext();

        // GET: Movies
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Genre).OrderBy(m=>m.GenreRefId).ThenBy(m=> m.MovieName);
            return View(movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.GenreRefId = new SelectList(db.Genres, "GenreId", "GenreName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,MovieName,MovieDirector,MovieYear,MovieDesc,GenreRefId,CreationDate")] Movie movie)
        {
            if (ModelState.IsValid)
            {

                movie.CreationDate = DateTime.Now;
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreRefId = new SelectList(db.Genres, "GenreId", "GenreName", movie.GenreRefId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreRefId = new SelectList(db.Genres, "GenreId", "GenreName", movie.GenreRefId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,MovieName,MovieDirector,MovieYear,MovieDesc,GenreRefId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.CreationDate = DateTime.Now;
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreRefId = new SelectList(db.Genres, "GenreId", "GenreName", movie.GenreRefId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
