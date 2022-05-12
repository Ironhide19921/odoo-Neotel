using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace Odoo
{
    /// <summary>
    /// Descripción breve de Odoo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Odoo : System.Web.Services.WebService
    {
 
       [WebMethod]
        public string getToken(string jsonprc,string db,string login,string password)
        {
            var client = new RestSharp.RestClient(ConfigurationManager.AppSettings["url"]+ "/web/session/authenticate");
            var request = new RestSharp.RestRequest(RestSharp.Method.POST);

            Params param = new Params(db, login, password);

            Root root = new Root(jsonprc, param);

            var json = JsonConvert.SerializeObject(root);

            request.AddParameter("application/json;charset=utf-8",json,ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;     


            var response = client.Execute(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }
            if (response.Cookies.Count == 0)
            {
                {
                    throw new Exception("Sin Cookies devueltas");
                }
            }

  

            return response.Cookies[0].Value;


        }
    }
}
