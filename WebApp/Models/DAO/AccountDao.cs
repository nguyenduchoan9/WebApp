using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Common;
using WepApp.CommonClass;

namespace WebApp.Models.DAO
{
    public class AccountDao
    {
        SqlDatabaseSybEntities db = null;

        public AccountDao()
        {
            db = new SqlDatabaseSybEntities();
        }

        public IEnumerable<Account> GetList()
        {
            var session = SessionStorage.GetSessionUser();
            var role = session.Role;

            if (Constant.SuperAdminRole == role)
            {
                return db.Accounts.Where(x => x.role != Constant.SuperAdminRole).ToList();
            }
            else if (Constant.AdminRole == role)
            {
                var id = session.Id;
                return db.Accounts.Where(x => x.role != Constant.SuperAdminRole && x.role != Constant.AdminRole).ToList();
            }
            return null;
        }

        public IEnumerable<Account> GetListPermission()
        {

            return db.Accounts.Where(x => x.role != Constant.SuperAdminRole
            && x.role != Constant.BanRole && x.role != Constant.BuyerRole).ToList();

        }

        public IEnumerable<Account> GetListBuyerSeller()
        {

            return db.Accounts.Where(x => x.role != Constant.SuperAdminRole
            && x.role != Constant.AdminRole && x.role != Constant.BanRole).ToList();

        }

        public bool Add()
        {
            Account acc = new Account();
            int maxId = db.Accounts.Max(x => x.id);
            int id = maxId + 1;
            acc.id = id;
            acc.username = "test1";
            acc.password = "test1";
            acc.address = "testAddress";
            acc.email = "test" + id + "@gmail.com";
            DateTime birthDate = new DateTime(1990, 10, 2, 2, 2, 2, DateTimeKind.Local);
            acc.birthdate = birthDate;
            acc.sex = true;
            acc.phone = "0901231231";
            acc.address = "123 abc";
            acc.role = 2;

            db.Accounts.Add(acc);
            int result = db.SaveChanges();
            if (result != 0)
            {
                return true;
            }
            return false;
        }

        /*
         * param: string username
         * output:
         *      -1 : username exist
         *       0 : username not exist
             */
        public int CheckUsernameExist(string username)
        {
            var userExist = db.Accounts.SingleOrDefault(x => x.username.Equals(username));
            if (null != userExist)
            {
                return -1;
            }
            return 0;
        }

        /*
         * param: string email
         * output:
         *      -1 : email exist
         *       0 : email not exist
             */
        public int CheckEmailExist(string email)
        {
            var emailExist = db.Accounts.SingleOrDefault(x => x.email.Equals(email));
            if (null != emailExist)
            {
                return -1;
            }
            return 0;
        }

        /*
         * param: Account acc
         * output:
         *      -1 : insert into DB error
         *       0 : insert successfully
           */
        public int RegisterAccount(Account acc)
        {
            int maxId = db.Accounts.Max(x => x.id);
            int id = maxId + 1;
            acc.id = id;
            try
            {
                db.Accounts.Add(acc);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
            return 0;
        }

        public Account CheckAccountLogin(string username, string password)
        {
            return db.Accounts.SingleOrDefault(x => x.username.Equals(username) && x.password.Equals(password));
        }

        public int BanAccount(int id)
        {
            var account = db.Accounts.Find(id);
            try
            {
                account.role = Constant.BanRole;
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
            return 0;
        }

        public int UnbanAccount(int id)
        {
            var account = db.Accounts.Find(id);
            try
            {
                account.role = Constant.CustomerRole;
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
            return 0;
        }

        public int ResetPassword(int id)
        {
            var account = db.Accounts.Find(id);
            /*Check account exist*/
            if (null == account)
            {
                return -2;
            }

            try
            {
                account.password = Constant.PasswordReset;
                db.Entry(account).State = EntityState.Unchanged;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
            return 0;
        }

        /* change role to admin*/
        public int ToAdmin(int id)
        {
            var account = db.Accounts.Find(id);

            if (null == account)
            {
                return -2;
            }

            try
            {
                account.role = Constant.AdminRole;
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
            return 0;
        }

        /* change role to customer*/
        public int ToUnadmin(int id)
        {
            var account = db.Accounts.Find(id);

            if (null == account)
            {
                return -2;
            }

            try
            {
                account.role = Constant.CustomerRole;
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
            return 0;
        }

        /* change role to customer*/
        public int ToCustomer(int id)
        {
            var account = db.Accounts.Find(id);

            if (null == account)
            {
                return -2;
            }

            try
            {
                account.role = Constant.CustomerRole;
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
            return 0;
        }

        /* change role to customer*/
        public int ToBuyer(int id)
        {
            var account = db.Accounts.Find(id);

            if (null == account)
            {
                return -2;
            }

            try
            {
                account.role = Constant.BuyerRole;
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
            return 0;
        }

        /*Get Usernmae by ID*/
        public string GetUsernameById(int id)
        {
            var account = db.Accounts.SingleOrDefault(x => x.id == id);
            if (null == account)
            {
                return null;
            }
            return account.username;
        }

        public void ConfigAcc()
        {
            int[] list = new int[16] {11,11,11,11,11,11,12,12,12,12,12,13,13,13,13,13};
            for (int i = 1; i < 17; i++)
            {
                int id = i;
                var product = db.Products.SingleOrDefault(x => x.id == id);
                int sellerId = list[i-1];
                product.sellerId = sellerId;

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}