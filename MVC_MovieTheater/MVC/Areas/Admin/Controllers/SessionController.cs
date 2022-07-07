using BLL.Concrete;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    public class SessionController : Controller
    {
        SessionService sessionService = new SessionService();

        // GET: Admin/Category
        public ActionResult Index()

        {
            return View(sessionService.GetList());
        }

        public ActionResult AddSession()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSession(Session session)
        {
            try
            {
                string result = sessionService.Add(session);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
            }

            return View();
        }


        public ActionResult UpdateSession(int id)
        {
            try
            {
                Session updated = sessionService.GetByID(id);
                return View(updated);
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdateSession(Session updated)
        {
            try
            {
                string result = sessionService.Update(updated);
                TempData["info"] = result;
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }

        public ActionResult DeleteSession(int id)
        {
            try
            {
                string result = sessionService.Delete(id);
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