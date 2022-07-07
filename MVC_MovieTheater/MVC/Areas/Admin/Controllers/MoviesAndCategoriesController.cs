using BLL.Concrete;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    public class MoviesAndCategoriesController : Controller
    {
        MoviesAndCategoriesService moviesAndCategoriesService = new MoviesAndCategoriesService();

        // GET: Admin/Category
        public ActionResult Index()

        {
            return View(moviesAndCategoriesService.GetList());
        }

        public ActionResult AddMoviesCategories()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMoviesCategories(MoviesAndCategories moviesAndCategories)
        {
            try
            {
                string result = moviesAndCategoriesService.Add(moviesAndCategories);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }

            return View();
        }


        public ActionResult UpdateMoviesCategories(int id)
        {
            try
            {
                MoviesAndCategories updated = moviesAndCategoriesService.GetByID(id);
                return View(updated);
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdateMoviesCategories(MoviesAndCategories updated)
        {
            try
            {
                string result = moviesAndCategoriesService.Update(updated);
                TempData["info"] = result;
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }

        public ActionResult DeleteMoviesCategories(int id)
        {
            try
            {
                string result = moviesAndCategoriesService.Delete(id);
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