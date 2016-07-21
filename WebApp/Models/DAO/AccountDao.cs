using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.DAO
{
    public class AccountDao
    {
        SqlDatabaseSybEntities db = null;

        public AccountDao()
        {
            db= new SqlDatabaseSybEntities();
        }

        public  IEnumerable<Account> GetList()
        {
            return db.Accounts.ToList();
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
            acc.email = "test"+ id +"@gmail.com";
            DateTime birthDate = new DateTime(1990,10,2,2,2,2, DateTimeKind.Local);
            acc.birthdate = birthDate;
            acc.sex = true;
            acc.phone = "0901231231";
            acc.address = "123 abc";
            acc.role = 5;

            db.Accounts.Add(acc);
            int result = db.SaveChanges();
            if (result != 0)
            {
                return true;
            }
            return false;
        }
    }
}