using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Common;
using WebApp.Common;
using WebApp.CommonClass;

namespace WepApp.CommonClass
{
    public class SessionStorage
    {
        public static void SetSessionUser(SessionUser session)
        {
            HttpContext.Current.Session[Key.SessionUser] = session;
        }

        public static SessionUser GetSessionUser()
        {
            var session = HttpContext.Current.Session[Key.SessionUser];

            if (null != session)
            {
                return session as SessionUser;
            }

            return null;
        }
    }
}