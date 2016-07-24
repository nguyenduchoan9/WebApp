using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Common;
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

        public void SendMail()
        {
            var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var toEmailAddress = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

            string content = System.IO.File.ReadAllText(Server.MapPath("~/Common/EmailTemplate/NewOrder.html"));

            content = content.Replace("{{CustomerName}}", "CustomerName");
            content = content.Replace("{{FromEmailAddress}}", fromEmailAddress);
            content = content.Replace("{{ToEmailAddress}}", toEmailAddress);

            new MailHelper().SendMail(toEmailAddress, "This is demo mail", content);

        }
    }
}