using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}