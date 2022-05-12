using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Odoo
{
    public class Params
    {
        public string db { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Params(string db, string login, string password)
        {
            this.db = db;
            this.login = login;
            this.password = password;
        }
    }

 

}