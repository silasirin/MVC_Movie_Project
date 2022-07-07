using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Cart
    {
        Dictionary<int, CartItem> _myCart = new Dictionary<int, CartItem>();

        public List<CartItem> myCart
        {
            get
            {
                return _myCart.Values.ToList();
            }
        }

        public void AddItem(CartItem cartItem)
        {
            if (_myCart.ContainsKey(cartItem.ID)) //Eger eklenen urunun ID'sini iceriyorsa, adeti artir.
            {
                _myCart[cartItem.ID].Quantity += cartItem.Quantity;
                return;
            }
            _myCart.Add(cartItem.ID, cartItem); //Eger eklenen urunun ID'sini icermiyorsa, urunu ekle
        }
    }
}