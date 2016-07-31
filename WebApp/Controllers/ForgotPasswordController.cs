using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Common;

namespace WebApp.Controllers
{
    public class ForgotPasswordController : Controller
    {
        // GET: ForgotPassword
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPassword(string email)
        {
            try
            {
                SendMail("hoangndse61505@fpt.edu.vn");
            }
            catch (Exception)
            {
                return View("SendMailErr");
            }
            return View();
        }

        private void SendMail(string toEmail)
        {
            var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var toEmailAddress = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

            string content = System.IO.File.ReadAllText(Server.MapPath("~/Common/EmailTemplate/EmailSendPassword.html"));
            
            content = content.Replace("{{FromEmailAddress}}", fromEmailAddress);
            content = content.Replace("{{ToEmailAddress}}", toEmail);
            content = content.Replace("{{NewPassword}}", Constant.PasswordReset);

            /*new MailHelper().SendMail(toEmailAddress, "This is demo mail", content);*/
            new MailHelper().SendMail(toEmail, "Get Your Password", content);
        }
    }
}