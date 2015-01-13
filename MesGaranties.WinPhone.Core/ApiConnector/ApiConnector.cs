using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MesGaranties.WinPhone.Core.ApiConnector.Connectors;
using MesGaranties.WinPhone.Core.ApiRequest;

namespace MesGaranties.WinPhone.Core.ApiConnector
{
    public class ApiConnector
    {
        private string _mail;
        private string _password;

        private CookieContainer _cookies;
        public GarantieConnector GarantieConnector { get; private set; }
        public bool IsConnected { get; private set; }
        public UsersConnector UsersConnector { get; private set; }

        public ApiConnector(string mail, string password)
        {
            _mail = mail;
            _password = password;
            _cookies = new CookieContainer();
            RequestGenerator.Cookie = _cookies;
            UsersConnector = new UsersConnector();
        }

        public async Task<bool> Login()
        {
            IsConnected = await UsersConnector.Login(_mail, _password);
            return IsConnected;
        }
    }
}
