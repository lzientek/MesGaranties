using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using MesGaranties.Core.Models;
using WebMatrix.WebData;

namespace MesGaranties.Api.Controllers
{
    public class UploadController : ApiController
    {
        private const string FileSaveLocation = "~/UserFiles";
        private MesGarantiesEntities db = new MesGarantiesEntities();

        
        [Route("Garanties/{id}/Files")]
        [Authorize]
        public HttpResponseMessage PostGarantieFiles([FromUri]int id)
        {
            var garantie = db.Garanties.Find(id);
            if (garantie == null || garantie.UserId != WebSecurity.CurrentUserId)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    "Id de la garantie innexistant ou vous ni avez pas les droit.");
            }
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                try
                {
                    var newFile = UploadFile(httpRequest, "PhotoProduit", garantie.Id, ".jpg", ".png");
                    if (newFile != string.Empty)
                    {
                        garantie.PhotoProduit = newFile;
                    }

                    newFile = UploadFile(httpRequest, "PhotoTicketDeCaisse", garantie.Id,
                        ".jpg", ".png");
                    if (newFile != string.Empty)
                    {
                        garantie.PhotoTicketDeCaisse = newFile;
                    }

                    newFile = UploadFile(httpRequest, "PhotoFicherAnnexe", garantie.Id,
                        ".jpg", ".png", ".pdf", ".doc", ".docx");
                    if (newFile != string.Empty)
                    {
                        garantie.PhotoFicherAnnexe = newFile;
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
                finally
                {
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.Created, garantie);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);

        }

        private string UploadFile(HttpRequest request, string fileName, int id, params string[] validExtension)
        {
            var postedFile = request.Files[fileName];
            if (postedFile != null && postedFile.ContentLength > 0)
            {
                string extension = Path.GetExtension(postedFile.FileName);
                if (validExtension.Length != 0 && !validExtension.Contains(extension))
                {
                    throw new BadImageFormatException(string.Format("Extension du fichier non valide. ({0})", string.Join(", ", validExtension)), fileName);
                }
                string path = string.Format("{0}/{1}{2}{3}", HttpContext.Current.Server.MapPath(FileSaveLocation), fileName, id, extension);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                postedFile.SaveAs(path);
                return string.Format("{0}/{1}{2}{3}", "/UserFiles", fileName, id, extension); ;
            }
            return string.Empty;
        }
    }


}
