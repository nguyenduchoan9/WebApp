using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Common;
using WebApp.CommonClass;
using WebApp.Models;
using WebApp.Models.DAO;
using WepApp.CommonClass;

namespace WebApp.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        public ActionResult Index()
        {
            var sessionCart = (List<CartItem>)Session[Constant.SessionCart];

            Decimal total = GetTotalPay(sessionCart);

            var session = SessionStorage.GetSessionUser();
            var username = session.Username;

            ViewBag.Username = username;
            ViewBag.TotalPay = total;

            return View();
        }

        public JsonResult Order(string deliveryDate, string deliveryAddress)
        {
            var sessionCustomer = SessionStorage.GetSessionUser();
            int idCustomer = sessionCustomer.Id;

            var sessionCart = (List<CartItem>)Session[Constant.SessionCart];
            Decimal total = GetTotalPay(sessionCart);

            DateTime deliveryDateTime = SplitDeliveryDate(deliveryDate);

            IEnumerable<OrderDetail> listOrderDetail = ListOrderDetail(sessionCart);

            OrderDao dao = new OrderDao();
            bool result = dao.AddNewOrder(idCustomer, deliveryDateTime, deliveryAddress, total, listOrderDetail);

            if (result)
            {
                Session[Constant.SessionCart] = null;
            }

            return Json(new
            {
                status = result
            });
        }

        private DateTime SplitDeliveryDate(string deliveryDate)
        {
            char[] delimiterChar = new char[1] { '-' };

            string[] words = deliveryDate.Split(delimiterChar);

            int dd = int.Parse(words[0]);
            int mm = int.Parse(words[1]);
            int yyyy = int.Parse(words[2]);

            DateTime date = new DateTime(yyyy,mm,dd);

            return date;
        }

        private Decimal GetTotalPay(List<CartItem> sessionCart)
        {
            ProductDao dao = new ProductDao();
            IEnumerable<CartItemDetail> listCartItemDetail = dao.ListCheckout(sessionCart);

            Decimal total = 0;

            foreach (var cartItemDetail in listCartItemDetail)
            {
                Decimal priceAfterDiscount = (Decimal)(cartItemDetail.Product.price - cartItemDetail.Product.price * cartItemDetail.Product.discount / 100);

                var totalPrice = (Decimal)(priceAfterDiscount * cartItemDetail.Quantity);

                total += totalPrice;
            }

            return total;
        }

        private IEnumerable<OrderDetail> ListOrderDetail(List<CartItem> sessionCart)
        {
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();

            OrderDetailDao orderDetailDao = new OrderDetailDao();
            int maxOrderDetailId = orderDetailDao.GetMaxIdOrderDatail();

            ProductDao productDao = new ProductDao();
            IEnumerable<CartItemDetail> listCartItemDetail = productDao.ListCheckout(sessionCart);


            foreach (var cartItemDetail in listCartItemDetail)
            {
                maxOrderDetailId ++;
                Decimal priceAfterDiscount =
                    (Decimal)
                        (cartItemDetail.Product.price - cartItemDetail.Product.price * cartItemDetail.Product.discount / 100);

                OrderDetail orderDetail = new OrderDetail();
                orderDetail.id = maxOrderDetailId;
                orderDetail.productId = cartItemDetail.Product.id;
                orderDetail.quantity = cartItemDetail.Quantity;
                orderDetail.soldPrice = priceAfterDiscount;

                listOrderDetail.Add(orderDetail);

            }


            return listOrderDetail;

        }

        public ActionResult OrderSuccess()
        {
            return View();
        }

        
    }
}