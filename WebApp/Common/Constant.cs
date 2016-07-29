using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Common
{
    public class Constant
    {
        /* Password reset*/
        public static string PasswordReset = "@123a123";

        /* Role : BAN */
        public static int SuperAdminRole = 0;

        /* Role : BAN */
        public static int AdminRole = 1;

        /* Role : BAN */
        public static int CustomerRole = 2;

        /* Role : BAN */
        public static int BanRole = 3;

        /* Role : BUYER */
        public static int BuyerRole = 4;

        /* ADMIN STRING*/
        public static string SuperAdmin = "SUPERADMIN";

        /* ADMIN STRING*/
        public static string Admin = "ADMIN";

        /* CUSTOMER STRING*/
        public static string Customer = "CUSTOMER";

        /* BAN STRING*/
        public static string Ban = "BAN";

        /* BUYER STRING*/
        public static string Buyer = "BUYER";

        /* MASSAGE ACCOUNT BAN*/
        public static string ErrMassageAccoutBan = "Your Account is banned !!!!!!";

        /* MASSAGE INVALID USERNAME OR PASSWORD*/
        public static string InvalidUsernameOrPassword = "Invalid username or password!";

        /*STRING UNADMIN*/
        public static string UnadminString = "UNADMIN";

        /* NOT HAVE PERMISSION*/
        public static string NoPermission = "YOU DON 'T HAVE PERMISSION";

        /*OrderDetailDao : string ListCustomizeOrderDetail*/
        public static string ListCustomizeOrderDetail = "ListCustomizeOrderDetail";

        /*OrderDetailDao : string SellerName*/
        public static string Seller = "Seller";
    }
}