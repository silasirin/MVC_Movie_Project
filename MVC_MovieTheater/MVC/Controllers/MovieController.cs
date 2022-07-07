using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        ProjectContext db = new ProjectContext();
       
        public PartialViewResult Details(int id)
        {
            var movies = db.Movies.Find(id);
            return PartialView(movies);
        }
    }
}