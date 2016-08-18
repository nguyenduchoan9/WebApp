using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Common;

namespace WebApp.Models.DAO
{
    public class OrderDetailDao
    {
        SqlDatabaseSybEntities db = null;

        public OrderDetailDao()
        {
            db = new SqlDatabaseSybEntities();
        }

        public Dictionary<string, object> GetOrderDetailList(int orderId)
        {
            var orderDetailList = db.OrderDetails.Where(x => x.orderId == orderId).ToList();
            var productList = db.Products.ToList();

            List<CustomizeOrderDetail> list = new List<CustomizeOrderDetail>();
            int sellerId = -1;
            foreach (var orderDetail in orderDetailList)
            {
                foreach (var product in productList)
                {
                    if (orderDetail.productId == product.id)
                    {
                        sellerId = product.sellerId;

                        CustomizeOrderDetail customize = new CustomizeOrderDetail(orderDetail, product);

                        list.Add(customize);
                        break;
                    }
                }
            }
            if (-1 == sellerId)
            {
                return null;
            }

            Account sellerAccount = db.Accounts.SingleOrDefault(x => x.id == sellerId);
            string sellerName = sellerAccount.username;

            Dictionary<string, Object> container = new Dictionary<string, object>();
            container.Add(Constant.ListCustomizeOrderDetail, list);
            container.Add(Constant.Seller, sellerName);

            return container;
        }

        public int GetMaxIdOrderDatail()
        {
            return db.OrderDetails.Max(x => x.id);
        }

    }
}