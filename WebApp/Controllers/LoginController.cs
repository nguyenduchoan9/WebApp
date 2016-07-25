using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Common;
using WebApp.CommonClass;
using WebApp.Models;
using WebApp.Models.DAO;
using WepApp.CommonClass;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }


        /*
         * Param: string username, stirng password
         * output:
         *      -1 : Invalid Usrename or password
         *      1 : SuperAdmin && Admin
         *      2 : Customer
         *      3 : Ban
         * 
         */
        [HttpPost]
        public JsonResult CheckLoginAccount(string username, string password)
        {
            AccountDao accDao = new AccountDao();
            Account user = accDao.CheckAccountLogin(username, password);

            if (null != user)
            {

                if (Constant.AdminRole == user.role || Constant.SuperAdminRole == user.role)
                {
                    SessionUser session = new SessionUser(user.id, user.username, user.role);
                    SessionStorage.SetSessionUser(session);
                    return Json(new
                    {
                        role = user.role,
                        massage = ""
                    });
                }
                else if (Constant.CustomerRole == user.role)
                {
                    SessionUser session = new SessionUser(user.id, user.username, user.role);
                    SessionStorage.SetSessionUser(session);
                    return Json(new
                    {
                        role = user.role,
                        massage = ""
                    });
                }

                /*ViewBag.ErrMassage = Constant.ErrMassageAccoutBan;*/
                return Json(new
                {
                    role = user.role,
                    massage = ""
                });

            }
            else
            {
                /*ViewBag.ErrMassage = Constant.InvalidUsernameOrPassword;*/
                return Json(new
                {
                    role = -1,
                    massage = Constant.InvalidUsernameOrPassword
                });
            }
        }
    }
}