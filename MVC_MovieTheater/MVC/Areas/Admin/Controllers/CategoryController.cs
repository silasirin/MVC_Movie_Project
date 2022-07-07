using BLL.Concrete;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService categoryService = new CategoryService();

        // GET: Admin/Category
        public ActionResult Index()

        {
            return View(categoryService.GetList());
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            try
            {
                string result = categoryService.Add(category);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }

            return View();
        }


        public ActionResult UpdateCategory(int id)
        {
            try
            {
                Category updated = categoryService.GetByID(id);
                return View(updated);
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category updated)
        {
            try
            {
                string result = categoryService.Update(updated);
                TempData["info"] = result;
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            try
            {
                string result = categoryService.Delete(id);
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