using MoviebasePartDeux.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviebasePartDeux.Controllers
{
    public class HomeController : Controller
    {
        private MbdbContext db = new MbdbContext();

        public ActionResult Index()
        {
            return View(db.Genres.ToList());
            //return View(db.Movies.ToList());   
        }
    }
    
}