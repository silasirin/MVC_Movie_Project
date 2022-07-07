using BLL.Concrete;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    public class WeekController : Controller
    {
        WeekService weekService = new WeekService();

        // GET: Admin/Category
        public ActionResult Index()

        {
            return View(weekService.GetList());
        }

        public ActionResult AddWeek()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWeek(Week week)
        {
            try
            {
                string result = weekService.Add(week);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }

            return View();
        }


        public ActionResult UpdateWeek(int id)
        {
            try
            {
                Week updated = weekService.GetByID(id);
                return View(updated);
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdateWeek(Week updated)
        {
            try
            {
                string result = weekService.Update(updated);
                TempData["info"] = result;
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }

        public ActionResult DeleteWeek(int id)
        {
            try
            {
                string result = weekService.Delete(id);
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