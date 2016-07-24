using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Models.DAO;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
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

        public JsonResult BanAccount(int id)
        {
            AccountDao dao = new AccountDao();
            var result = dao.BanAccount(id);
            bool resultJson = -1 != result;
            return Json(new
            {
                status = resultJson
            });
        }

        public JsonResult UnbanAccount(int id)
        {
            AccountDao dao = new AccountDao();
            var result = dao.UnbanAccount(id);
            bool resultJson = -1 != result;
            return Json(new
            {
                status = resultJson
            });
        }

        public JsonResult ResetPassword(int id)
        {
            AccountDao dao = new AccountDao();
            var result = dao.ResetPassword(id);
            bool resultJson = -1 != result;
            return Json(new
            {
                status = resultJson
            });
        }
    }
}