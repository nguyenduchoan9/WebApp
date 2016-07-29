using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Common;
using WebApp.Models;
using WebApp.Models.DAO;
using WepApp.CommonClass;

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

        public void SendMail()
        {
            var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var toEmailAddress = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

            string content = System.IO.File.ReadAllText(Server.MapPath("~/Common/EmailTemplate/NewOrder.html"));

            content = content.Replace("{{CustomerName}}", "CustomerName");
            content = content.Replace("{{FromEmailAddress}}", fromEmailAddress);
            content = content.Replace("{{ToEmailAddress}}", "huyennblse61299@fpt.edu.vn");

            /*new MailHelper().SendMail(toEmailAddress, "This is demo mail", content);*/
            new MailHelper().SendMail("huyennblse61299@fpt.edu.vn", "This is demo mail", content);
        }

        public ActionResult PermissionPage()
        {
            var session = SessionStorage.GetSessionUser();
            var role = session.Role;
            if (Constant.SuperAdminRole == role)
            {
                AccountDao dao = new AccountDao();
                IEnumerable<Account> model = dao.GetListPermission();
                return View(model);
            }

            ViewBag.Msg = Constant.NoPermission;
            return View("NoPermission");
        }

        [HttpPost]
        public JsonResult ToAdmin(int id)
        {
            AccountDao dao = new AccountDao();
            var result = dao.ToAdmin(id);
            bool resultJson = -1 != result;
            return Json(new
            {
                status = resultJson
            });
        }

        [HttpPost]
        public JsonResult ToUnadmin(int id)
        {
            AccountDao dao = new AccountDao();
            var result = dao.ToUnadmin(id);
            bool resultJson = -1 != result;
            return Json(new
            {
                status = resultJson
            });
        }

        public ActionResult BuyerSellerPage()
        {
            var session = SessionStorage.GetSessionUser();
            var role = session.Role;
            if (Constant.SuperAdminRole == role)
            {
                AccountDao dao = new AccountDao();
                IEnumerable<Account> model = dao.GetListBuyerSeller();
                return View(model);
            }
            ViewBag.Msg = Constant.NoPermission;
            return View("NoPermission");

        }

        [HttpPost]
        public JsonResult ToCustomer(int id)
        {
            AccountDao dao = new AccountDao();
            var result = dao.ToCustomer(id);
            bool resultJson = -1 != result;
            return Json(new
            {
                status = resultJson
            });
        }

        [HttpPost]
        public JsonResult ToBuyer(int id)
        {
            AccountDao dao = new AccountDao();
            var result = dao.ToBuyer(id);
            bool resultJson = -1 != result;
            return Json(new
            {
                status = resultJson
            });
        }

        public void AccConfig()
        {
            AccountDao dao = new AccountDao();
            dao.ConfigAcc();
        }
    }
}