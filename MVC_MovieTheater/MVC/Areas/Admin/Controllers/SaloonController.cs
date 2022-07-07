using BLL.Concrete;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    public class SaloonController : Controller
    {
        SaloonService saloonService = new SaloonService();

        // GET: Admin/Category
        public ActionResult Index()

        {
            return View(saloonService.GetList());
        }

        public ActionResult AddSaloon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSaloon(Saloon saloon)
        {
            try
            {
                string result = saloonService.Add(saloon);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }

            return View();
        }


        public ActionResult UpdateSaloon(int id)
        {
            try
            {
                Saloon updated = saloonService.GetByID(id);
                return View(updated);
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdateSaloon(Saloon updated)
        {
            try
            {
                string result = saloonService.Update(updated);
                TempData["info"] = result;
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }

        public ActionResult DeleteSaloon(int id)
        {
            try
            {
                string result = saloonService.Delete(id);
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