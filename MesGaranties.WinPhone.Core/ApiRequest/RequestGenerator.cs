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
        public const string uri = "http://api.mg.com/";
        public static CookieContainer Cookie { get; set; }
        
        /// <summary>
        /// Post request
        /// </summary>
        /// <param name="url">route</param>
        /// <param name="body">content</param>
        /// <returns>result</returns>
        public static async Task<HttpResponseMessage> PostRequest(string url, string body)
        {
            using (var handler = new HttpClientHandler() { CookieContainer = Cookie, UseCookies = true })
            using (var client = new HttpClient(handler))
            using (var content = new StringContent(body, Encoding.UTF8))
            {
                var result = await client.PostAsync(string.Format("{0}{1}", uri, url), content);
                return result;
            }

        }

        /// <summary>
        /// Get request
        /// </summary>
        /// <param name="url">route</param>
        /// <returns>result</returns>
        public static async Task<HttpResponseMessage> GetRequest(string url)
        {
            using (var handler = new HttpClientHandler() { CookieContainer = Cookie, UseCookies = true })
            using (var client = new HttpClient(handler))
            {
                var result = await client.GetAsync(string.Format("{0}{1}", uri, url));
                return result;
            }
        }

        /// <summary>
        /// Put values
        /// </summary>
        /// <param name="url">route</param>
        /// <param name="body">content</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> PutRequest(string url, string body)
        {
            using (var handler = new HttpClientHandler() { CookieContainer = Cookie, UseCookies = true })
            using (var client = new HttpClient(handler))
            using (var content = new StringContent(body, Encoding.UTF8))
            {
                var result = await client.PutAsync(string.Format("{0}{1}", uri, url), content);
                return result;
            }
        }

        /// <summary>
        /// send a file
        /// </summary>
        /// <param name="url">request route</param>
        /// <param name="rdr">file stream</param>
        /// <param name="destFile">name</param>
        /// <param name="fileName">filename</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> PostFile(string url,Stream rdr,string destFile ,string fileName )
        {

            HttpContent fileStreamContent = new StreamContent(rdr);

            using (var handler = new HttpClientHandler()
            {
                CookieContainer = Cookie,
                UseCookies = true,

            })
            using (var client = new HttpClient(handler))
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(fileStreamContent, destFile, fileName);

                var response = await client.PostAsync(string.Format("{0}{1}",uri, url), formData);
                return response;
            }
        }
    }
}
