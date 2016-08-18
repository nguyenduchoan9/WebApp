using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.CommonClass
{
    [Serializable]
    public class CartItem
    {
        public int IdProduct { get; set; }
        public int Quantity { get; set; }

        public CartItem()
        {
            
        }

        public CartItem(int idProduct, int quantity)
        {
            this.IdProduct = idProduct;
            this.Quantity = quantity;
        }
    }
}