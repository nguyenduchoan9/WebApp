using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Common;
using WebApp.CommonClass;
using WebApp.Models.DAO;
using System.Web.Script.Serialization;

namespace WebApp.Controllers
{
    public class ShoppingCartController : Controller
    {
        public JsonResult AddIemToCart(int idProduct, int quantity)
        {
            var sessionCart = Session[Constant.SessionCart];

            if (null != sessionCart)
            {
                var list = (List<CartItem>)sessionCart;
                if (list.Exists(x => x.IdProduct == idProduct))
                {
                    foreach (var item in list)
                    {
                        if (item.IdProduct == idProduct)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    // create new cart item
                    var item = new CartItem(idProduct, quantity);

                    // add cart item to list
                    list.Add(item);
                }

                Session[Constant.SessionCart] = list;

            }
            else
            {
                // create new cart item
                var item = new CartItem(idProduct, quantity);

                // add cart item to list
                var list = new List<CartItem>();
                list.Add(item);

                // add list to session
                Session[Constant.SessionCart] = list;

            }

            return Json(new
            {
                status = true
            });
        }

        public ActionResult ShowShoppingCartOut()
        {
            var sessionCart = Session[Constant.SessionCart];
            var list = (List<CartItem>)sessionCart;

            ProductDao dao = new ProductDao();
            IEnumerable<CartItemDetail> model = dao.ListCheckout(list);

            return View(model);
        }

        public ActionResult ResetCart()
        {
            var listCartItem = new List<CartItem>();
            Session[Constant.SessionCart] = listCartItem;

            return View("ShowShoppingCartOut");
        }

        public JsonResult UpdateCart(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>) Session[Constant.SessionCart];

            foreach (var cart in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.IdProduct == cart.IdProduct);
                if (null != jsonItem)
                {
                    cart.Quantity = jsonItem.Quantity;
                }
            }

            Session[Constant.SessionCart] = sessionCart;

            return Json(new
            {
                status = true
            });

        }

        public JsonResult RemoveProductFromShoppingCart(int id)
        {
            var sessionCart = (List<CartItem>)Session[Constant.SessionCart];

            sessionCart.RemoveAll(x => x.IdProduct == id);

            Session[Constant.SessionCart] = sessionCart;

            return Json(new
            {
                status = true
            });
        }
    }
}