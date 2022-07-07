using BLL.Concrete;
using Common;
using DataAccess.Context;
using DataAccess.Entity;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        AppUserService appUserService = new AppUserService();
        MovieService movieService = new MovieService();
        ProjectContext db = new ProjectContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(movieService.GetDefault(x => x.Status == Core.Enums.Status.Active));
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(AppUserVM appUserVM)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.UserName = appUserVM.UserName;
                appUser.Email = appUserVM.Email;
                appUser.Password = appUserVM.Password;
                appUser.ActivationCode = Guid.NewGuid();
                var result = appUserService.Add(appUser);
                TempData["info"] = result;

                //MailSender
                MailSender.SendEmail(appUserVM.Email, "Uyelik Aktivasyonu", $"Uyeliginizi aktif hale getirebilmek icin linke tiklayiniz.");

                return RedirectToAction("Pending");

            }
            else
            {
                return View(appUserVM);
            }
        }

        public ActionResult Activation(Guid id)
        {
            if (id != null)
            {
                AppUser user = appUserService.GetDefault(x => x.ActivationCode == id).FirstOrDefault();
                user.IsActive = true;

                appUserService.Update(user);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Register");
            }

        }

        public ActionResult Pending(AppUser user)
        {
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (db.AppUsers.Any(x => x.UserName == appUser.UserName && x.Password == appUser.Password))
                    {
                        AppUser user = db.AppUsers.Where(x => x.UserName == appUser.UserName && x.Password == appUser.Password).FirstOrDefault();

                        Session["scart"] = user;
                        return RedirectToAction("MyCart");
                    }
                    else
                    {
                        TempData["error"] = "Kullanıcı adı veya şifre hatalı!";
                        return View(appUser);
                    }
                }
                catch (Exception)
                {
                    return View();
                }
            }
            else
            {
                return View(appUser);
            }
        }

        public ActionResult AddToCart(int id)
        {
            try
            {
                Movie movie = db.Movies.Find(id);

                Cart c = null;

                if (Session["scart"] == null) //oturum acilmamissa scart isimli bir session olustur.
                {
                    c = new Cart();

                }
                else //scart isimli bir session varsa, var olan oturumu kullan
                {
                    c = Session["scart"] as Cart; //scart isimli session'i cart olarak unboxing yap ve icerisine at.                   
                }

                //veya ternary if ile asagidaki sekilde de yazilabilir:

                //Card c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;

                CartItem ci = new CartItem();
                ci.ID = movie.MovieID;
                ci.Price = movie.UnitPrice; //Bos gecilebilir bir degere bos gecilemez bir deger aktarilamaz. bu nedenle property'ler duzeltilir.
                ci.MovieName = movie.MovieName;
                c.AddItem(ci); //oturum icerisindeki karta kart item'larini ekle.
                Session["scart"] = c;

                return RedirectToAction("MyCart");
            }
            catch (Exception)
            {
                TempData["error"] = $"{id} karsilik gelen bir film bulunamadi!";
                return View();
            }
            
        }
        public ActionResult MyCart()
        {
            if (Session["scart"] != null)
            {
                return View();
            }
            else
            {
                TempData["error"] = "Sepetinizde film bulunmamaktadir!";
                return RedirectToAction("Index");
            }
        }

        public ActionResult CompleteCart()
        {
            Cart cart = Session["scart"] as Cart;
            foreach (var item in cart.myCart)
            {
                Movie movie = db.Movies.Find(item.ID);
                //Theater theater = db.Theaters.Where(x=>x.MovieID)
                Saloon saloon = new Saloon();
                saloon.Capacity -= Convert.ToInt16(item.Quantity); //stogu adet kadar dusur
                db.Entry(movie).State = System.Data.Entity.EntityState.Modified; //degisiklikleri sisteme modifiye et.
                db.SaveChanges(); //kaydet
                ViewBag.OrderNo = "dh2830lfdhf730";
                Session.Remove("scart"); //scard isimli session'i bosalt.
            }
            return View();
        }
    }
}