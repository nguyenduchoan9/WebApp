using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class CustomizeOrder
    {
        public Order Order { get; set; }
        public string  Username { get; set; }

        public CustomizeOrder()
        {
            
        }

        public CustomizeOrder(Order order, string username)
        {
            this.Order = order;
            this.Username = username;
        }
    }
}