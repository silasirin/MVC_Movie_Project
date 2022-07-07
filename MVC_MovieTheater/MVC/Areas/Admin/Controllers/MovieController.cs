using BLL.Concrete;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    public class MovieController : Controller
    {
        MovieService movieService = new MovieService();

        // GET: Admin/Category
        public ActionResult Index()

        {
            return View(movieService.GetList());
        }

        public ActionResult AddMovie()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMovie(Movie movie)
        {
            try
            {
                string result = movieService.Add(movie);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }

            return View();
        }


        public ActionResult UpdateMovie(int id)
        {
            try
            {
                Movie updated = movieService.GetByID(id);
                return View(updated);
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdateMovie(Movie updated)
        {
            try
            {
                string result = movieService.Update(updated);
                TempData["info"] = result;
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }

        public ActionResult DeleteMovie(int id)
        {
            try
            {
                string result = movieService.Delete(id);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return View();
            }
        }
    }
}