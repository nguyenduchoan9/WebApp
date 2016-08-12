using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApp.Models;
using WebApp.Models.DAO;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {   
            ProductDao dao = new ProductDao();
            IEnumerable<Product> model = dao.GetList();
            return View(model);
        }

        [HttpPost]
        public JsonResult GetProductById(int id)
        {
            ProductDao dao = new ProductDao();
            Product product = dao.GetProductById(id);
            var json = new JavaScriptSerializer().Serialize(product);
            return Json(new
            {
                product = json
            });
        }

        [HttpPost]
        public JsonResult UpdateProduct(int id, string productName, Decimal price, int discount, string description, string image)
        {
            ProductDao dao = new ProductDao();

            bool status = dao.UpdateProduct(id, productName, price, discount, description, image);
            
            if (status)
            {
                Product product = dao.GetProductById(id);
                var jsonProduct = new JavaScriptSerializer().Serialize(product);

                return Json(new
                {
                    product = jsonProduct
                });
            }
            return Json(new
            {
                
            });
        }

        [HttpPost]
        public JsonResult DeleteProduct(int id)
        {
            ProductDao dao = new ProductDao();

            bool result = dao.DeleteProductById(id);
            
            return Json(new
            {
                status = result
            });
        }


        public JsonResult Change()
        {
            ProductDao dao = new ProductDao();

            dao.Change();
            return Json(new
            {
                
            });
        }
    }
}