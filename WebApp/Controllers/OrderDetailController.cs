using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Common;
using WebApp.Models;
using WebApp.Models.DAO;

namespace WebApp.Controllers
{
    public class OrderDetailController : Controller
    {
        // GET: OrderDetail
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewDetail(int orderId, string buyerName, double total)
        {
            OrderDetailDao dao = new OrderDetailDao();
            Dictionary<string, object> container = dao.GetOrderDetailList(orderId);

            IEnumerable<CustomizeOrderDetail> model = null;
            if (container.ContainsKey(Constant.ListCustomizeOrderDetail))
            {
                model = (List<CustomizeOrderDetail>)container[Constant.ListCustomizeOrderDetail];
            }

            string sellerName = null;
            if (container.ContainsKey(Constant.Seller))
            {
                sellerName = (string)container[Constant.Seller];
            }
            
            ViewBag.SellerName = sellerName;
            ViewBag.BuyerName = buyerName;
            ViewBag.Total = total;

            return View(model);
        }

        
    }
}