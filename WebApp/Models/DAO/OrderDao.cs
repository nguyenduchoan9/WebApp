using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
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

        public bool AddNewOrder(int idBuyer, DateTime deliveryDateTime, string deliveryAddress, Decimal total, IEnumerable<OrderDetail> listOrderDetail)
        {
            try
            {
                int maxOrderId = db.Orders.Max(x => x.id);
                int orderId = maxOrderId + 1;

                Order order = new Order();
                order.id = orderId;
                order.buyerId = idBuyer;
                order.orderDate = DateTime.Now;
                order.DeleveryDate = deliveryDateTime;
                order.total = total;
                order.DeliveryAddress = deliveryAddress;

                db.Orders.Add(order);

                foreach (var orderDetail in listOrderDetail)
                {
                    orderDetail.orderId = orderId;
                    db.OrderDetails.Add(orderDetail);
                }

                db.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

       
    }
}