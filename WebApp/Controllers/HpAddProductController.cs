using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.DAO;
using WepApp.CommonClass;

namespace WebApp.Controllers
{
    public class HpAddProductController : Controller
    {
        // GET: HPAddProduct
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult RegisterProduct(string productName, Decimal price, int discount, string description, string image)
        {
            

            ProductDao dao = new ProductDao();
            int existProductName = dao.CheckProductNameExist(productName);
            int status = 0;
            /*Product name exist => status = -1*/
            status = -1 == existProductName ? -1 : 0;
            if (-1 == status)
            {
                return Json(new
                {
                    status = status
                });
            }

            image = "/Content/Customer/images/" + image;

            Product product = new Product();
            product.sellerId = 1;
            product.name = productName;
            product.image = image;
            product.price = price;
            product.discount = discount;
            product.description = description;

            int insertSuccess = dao.AddNewProduct(product);
            status = -1 == insertSuccess ? -2 : 0;

            return Json(new
            {
                status = status
            });
        }

        public ActionResult AddProductSuccessPage()
        {
            return View();
        }
    }
}