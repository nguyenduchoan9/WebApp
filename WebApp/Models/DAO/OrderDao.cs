using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Common;

namespace WebApp.Models.DAO
{
    public class OrderDao
    {
        SqlDatabaseSybEntities db = null;

        public OrderDao()
        {
            db = new SqlDatabaseSybEntities();
        }

        public IEnumerable<CustomizeOrder> GetListOrder()
        {
            var order = db.Orders.ToList();
            var account = db.Accounts.ToList();

            List<CustomizeOrder> list = new List<CustomizeOrder>();

            foreach (var item in order)
            {
                string username = "";
                foreach (var acc in account)
                {
                    if (item.buyerId == acc.id)
                    {
                        username = acc.username;

                        CustomizeOrder cusOrder = new CustomizeOrder(item, username);
                        list.Add(cusOrder);
                        break;
                    }
                }


            }

            return list;
        }
    }
}