using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Common;
using WebApp.CommonClass;
using WebApp.Models;
using WebApp.Models.DAO;

namespace WebApp.Controllers
{
    public class HpShowProductController : Controller
    {
        // GET: HpShowProduct
        public ActionResult Index()
        {
            ProductDao dao = new ProductDao();
            IEnumerable<Product> model = dao.ListProductHomePage();
            return View(model);
        }


        public ActionResult ViewDetailProduct(int id)
        {
            ProductDao dao = new ProductDao();
            var product = dao.GetProductById(id);

            return View(product);
        }
    }
}