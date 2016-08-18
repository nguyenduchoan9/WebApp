using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.DAO;

namespace WebApp.Controllers
{
    public class SearchingController : Controller
    {
        [HttpPost]
        public ActionResult Searching(string txtSearchKey)
        {
            ProductDao dao = new ProductDao();
            IEnumerable<Product> model = dao.GetProductBySearchKey(txtSearchKey);

            ViewBag.TxtSearchKey = txtSearchKey;
            return View(model);
        }
        
    }
}