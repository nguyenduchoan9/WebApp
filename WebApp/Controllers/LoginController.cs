using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.DAO;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            AccountDao dao = new AccountDao();
            IEnumerable<Account> model = dao.GetList();
            return View(model);
        }

        public ActionResult Add()
        {
            AccountDao dao = new AccountDao();
            bool result = dao.Add();
            return RedirectToAction("Index");
        }
    }
}