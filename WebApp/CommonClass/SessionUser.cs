using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace WebApp.CommonClass
{
    public class SessionUser
    {
        public SessionUser(int id, string username)
        {
            this.Id = id;
            this.Username = username;
        }

        public int Id { get; set; }
        public string Username { get; set; }
    }
}