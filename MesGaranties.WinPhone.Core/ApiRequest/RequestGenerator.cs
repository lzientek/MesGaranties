using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MesGaranties.WinPhone.Core.ApiRequest
{
    public class RequestGenerator
    {

        public static async Task<HttpResponseMessage> PostRequest(string url, CookieContainer cookie, string body)
        {
            using (var handler = new HttpClientHandler() { CookieContainer = cookie,UseCookies = true})
            using (var client = new HttpClient(handler))
            using (var content = new StringContent(body, Encoding.UTF8))
            {
                var result = await client.PostAsync(url, content);
                return result;
            }

        }


    }
}
