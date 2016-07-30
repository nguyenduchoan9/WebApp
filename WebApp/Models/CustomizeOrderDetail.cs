using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class CustomizeOrderDetail
    {
        public OrderDetail OrderDetail { get; set; }
        public Product Product { get; set; }

        public CustomizeOrderDetail()
        {
            
        }

        public CustomizeOrderDetail(OrderDetail orderDetail, Product product)
        {
            this.OrderDetail = orderDetail;
            this.Product = product;
        }
    }
}