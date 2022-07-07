using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class CartItem
    {
        public CartItem()
        {
            Quantity = 1;
        }

        //bir alisveris sepetinin ....si olur
        public int ID { get; set; }
        public string MovieName { get; set; }
        public decimal Quantity { get; set; }
        public decimal? Price { get; set; } //veritabanindan gelen price bos gecilebilir oldugundan dolayi buradaki price ve subtotal alanlarini da bos gecilebilir yapmamiz gerekti.

        //subtotal kendi adet ve fiyat bilgileriyle calisacaktir. Dısaridan bir ayarlamaya yapilmayacak. Readonly olacak. Bu nedenle set'i siliyoruz.
        public decimal? SubTotal
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}