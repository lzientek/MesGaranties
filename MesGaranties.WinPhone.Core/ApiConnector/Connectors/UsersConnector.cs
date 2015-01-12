using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MesGaranties.WinPhone.Core.ApiConnector.Connectors
{
    public class UsersConnector
    {
        public CookieContainer CookieContainer { get; set; }
        public bool Login(string mail, string pass)
        {
            
            var result = ApiRequest.RequestGenerator.PostRequest("http://api.mg.com/Connection",
                CookieContainer, string.Format("{{ \"Mail\":\"{0}\", \"Password\":\"{1}\" }}", mail, pass));
            return result.Result.IsSuccessStatusCode;
        }
    }
}
