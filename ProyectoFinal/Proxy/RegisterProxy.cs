using ProyectoFinal.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Proxy
{
    public class RegisterProxy
    {

        public string _urlBase = URLConstant.UrlBase;
        public string _endPoint = $"{URLConstant.Prefix}{URLConstant.Login}";
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

    }
}