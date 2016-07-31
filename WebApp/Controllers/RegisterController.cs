using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.DAO;

namespace WebApp.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Register(string email, string birthdate, string sex, string address, string phone, string username,
            string password)
        {
            AccountDao dao = new AccountDao();

            int status = 0;
            int usernameExist = dao.CheckUsernameExist(username);
            if (-1 == usernameExist)
            {
                /*username exist: status = 1*/
                status = -1;
            }

            int emailExist = dao.CheckEmailExist(email);
            if (-1 == emailExist)
            {
                /*email exist: status = 2*/
                /*username and email exist: status = 3*/
                status = status == -1 ? -3 : -2;

            }

            if (0 != status)
            {
                return Json(new
                {
                    status = status
                });
            }

            DateTime birthdateAcc = splitBirthdate(birthdate);
            bool sexAcc = sex.Equals("1") ? true : false;

            bool result = dao.AddNewAccount(email, birthdateAcc, sexAcc, address, phone, username, password);


            return Json(new
            {
                status = result
            });
        }

        private DateTime splitBirthdate(string birthdate)
        {
            char[] delimiterChar = new char[1] {'-'};

            string[] words = birthdate.Split(delimiterChar);

            int dd = int.Parse(words[0]);
            int mm = int.Parse(words[1]);
            int yyyy = int.Parse(words[2]);

            DateTime date = new DateTime(yyyy,mm, dd);

            return date;
        }

        public ActionResult RegisterSuccess()
        {
            return View();
        }
    }
}