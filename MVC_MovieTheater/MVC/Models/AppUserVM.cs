using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class AppUserVM
    {
        [Required(ErrorMessage = "Kullanici adi giriniz!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Sifre giriniz!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Sifre tekrar giriniz!")]
        [Compare("Password", ErrorMessage = "Sifreler ayni degil!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email giriniz!")]
        public string Email { get; set; }
    }
}