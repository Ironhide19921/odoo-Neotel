using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Odoo
{
    public class Root
    {
        public string jsonrpc { get; set; }
        public Params @params { get; set; }

        public Root(string jsonrpc, Params @params)
        {
            this.jsonrpc = jsonrpc;
            this.@params = @params;
        }
    }

}