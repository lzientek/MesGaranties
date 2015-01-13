using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MesGaranties.WinPhone.Core.ApiConnector.Models;
using MesGaranties.WinPhone.Core.ApiRequest;
using Newtonsoft.Json;

namespace MesGaranties.WinPhone.Core.ApiConnector.Connectors
{
    public class UsersConnector
    {
        public bool Login(string mail, string pass)
        {
            try
            {
                var result = ApiRequest.RequestGenerator.PostRequest("Connection",
                    string.Format("{{ \"Mail\":\"{0}\", \"Password\":\"{1}\" }}", mail, pass));
                return result.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<UserDetailModel> ActualUser()
        {
            var result = RequestGenerator.GetRequest("Me");
            result.Result.EnsureSuccessStatusCode();
            var deserialized = JsonConvert.DeserializeObject<UserDetailModel>(
                await result.Result.Content.ReadAsStringAsync());
            return deserialized;
        }
    }
}
