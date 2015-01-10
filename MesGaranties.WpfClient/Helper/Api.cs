using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MesGaranties.WpfClient.Helper
{
    class Api
    {
        CookieContainer cookies = new CookieContainer();
        public Stream SendFile(string path,int id)
        {
            FileStream rdr = new FileStream(path, FileMode.Open, FileAccess.Read);

           

            HttpContent fileStreamContent = new StreamContent(rdr);

            // Submit the form using HttpClient and 
            // create form data as Multipart (enctype="multipart/form-data")
            using (var handler = new HttpClientHandler()
            {
                CookieContainer = cookies,
                
            })
            using (var client = new HttpClient(handler))
            using (var formData = new MultipartFormDataContent())
            {
                // Add the HttpContent objects to the form data

                formData.Add(fileStreamContent, "PhotoProduit", Path.GetFileName(path));

                // Actually invoke the request to the server

                // equivalent to (action="{url}" method="post")
                var response = client.PostAsync(string.Format("http://api.mg.com/Garanties/{0}/Files", id), formData).Result;

                // equivalent of pressing the submit button on the form
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                return response.Content.ReadAsStreamAsync().Result;
            }




        }

        public void Connection(string mail, string pass)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://api.mg.com/Connection");
            req.KeepAlive = false;
            req.ContentType = "application/json";
            req.Method = "POST";    
            req.AllowWriteStreamBuffering = true;
            byte[] buf = Encoding.UTF8.GetBytes(string.Format("{{ \"Mail\":\"{0}\", \"Password\":\"{1}\" }}", mail,pass));
            req.GetRequestStream().Write(buf, 0, buf.Length);
            
            HttpWebResponse TheResponse = (HttpWebResponse)req.GetResponse();
            cookies.SetCookies(TheResponse.ResponseUri, TheResponse.Headers.Get("Set-Cookie"));
            string TheResponseString1 = new StreamReader(TheResponse.GetResponseStream(), Encoding.ASCII).ReadToEnd();
            TheResponse.Close();
        }
    }
}
