using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.DAO;

namespace WebApp.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            OrderDao dao = new OrderDao();
            IEnumerable<CustomizeOrder> model = dao.GetListOrder();
            return View(model);
        }
    }
}