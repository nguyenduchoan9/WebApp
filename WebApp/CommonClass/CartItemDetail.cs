using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.CommonClass
{
    [Serializable]
    public class CartItemDetail
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public CartItemDetail()
        {
            
        }

        public CartItemDetail(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }
    }
}