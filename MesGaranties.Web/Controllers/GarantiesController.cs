using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DansTesComs.WebSite.Filters;
using MesGaranties.Core.Models;
using WebMatrix.WebData;

namespace MesGaranties.WebSite.Controllers
{
    [InitializeSimpleMembership]
    public class GarantiesController : Controller
    {
        // ReSharper disable once InconsistentNaming
        private readonly MesGarantiesEntities db = new MesGarantiesEntities();

        // GET: Garanties
        public ActionResult Index()
        {
            var garanties = db.Garanties.Where(g => g.UserId == WebSecurity.CurrentUserId);
            return View(garanties.ToList());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garantie garantie = db.Garanties.Find(id);
            if (garantie == null)
            {
                return HttpNotFound();
            }
            if (garantie.UserId != WebSecurity.CurrentUserId)
            {
                return new HttpUnauthorizedResult("Bad User");
            }
            return View(garantie);
        }

        // GET: Garanties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Garanties/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Commentaire,FinDeGarantie")] Garantie garantie)
        {
            garantie.LastModificationDate = DateTime.Now;
            garantie.CreationDate = DateTime.Now;
            garantie.UserId = WebSecurity.CurrentUserId;
            if (ModelState.IsValid)
            {
                db.Garanties.Add(garantie);
                db.SaveChanges();

                try
                {
                    garantie.PhotoProduit = UploadFile("PhotoProduit", garantie.Id, ".jpg", ".png");
                    garantie.PhotoTicketDeCaisse = UploadFile("PhotoTicketDeCaisse", garantie.Id, ".jpg", ".png");
                    garantie.PhotoFicherAnnexe = UploadFile("PhotoFicherAnnexe", garantie.Id,
                         ".jpg", ".png", ".pdf", ".doc", ".docx");
                    return RedirectToAction("Index");
                }
                catch (BadImageFormatException ex)
                {
                    db.Garanties.Remove(garantie);
                    ModelState.AddModelError(ex.FileName, ex.Message);

                }
                catch (Exception exe)
                {
                    ModelState.AddModelError("", exe.Message);

                }
                finally
                {
                    db.SaveChanges();
                }

            }
            return View(garantie);
        }

        public string UploadFile(string fileName, int id, params string[] validExtension)
        {
            if (Request.Files[fileName].ContentLength > 0)
            {
                string extension = System.IO.Path.GetExtension(Request.Files[fileName].FileName);
                if (validExtension.Length != 0 && !validExtension.Contains(extension))
                {
                    throw new BadImageFormatException(string.Format("Extension du fichier non valide. ({0})", string.Join(", ", validExtension)), fileName);
                }
                string path1 = string.Format("{0}/{1}{2}{3}", Server.MapPath("~/UserFiles"), fileName, id, extension);
                if (System.IO.File.Exists(path1))
                {
                    System.IO.File.Delete(path1);
                }
                Request.Files[fileName].SaveAs(path1);
                return string.Format("{0}/{1}{2}{3}", "/UserFiles", fileName, id, extension); ;
            }
            return string.Empty;
        }

        // GET: Garanties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garantie garantie = db.Garanties.Find(id);
            if (garantie == null)
            {
                return HttpNotFound();
            }
            if (garantie.UserId != WebSecurity.CurrentUserId)
            {
                return new HttpUnauthorizedResult("Bad User");
            }
            return View(garantie);
        }

        // POST: Garanties/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Commentaire,FinDeGarantie")] Garantie garantie)
        {
            if (ModelState.IsValid)
            {
                Garantie gar = db.Garanties.Find(garantie.Id);
                try
                {
                    gar.Name = garantie.Name;
                    gar.Commentaire = garantie.Commentaire;
                    gar.FinDeGarantie = garantie.FinDeGarantie;
                    gar.LastModificationDate = DateTime.Now;

                    //si aucune nouvelle photo a été ajouté on modifie pas
                    var photo = UploadFile("PhotoProduit", garantie.Id, ".jpg", ".png");
                    if (!string.IsNullOrWhiteSpace(photo)) { gar.PhotoProduit = photo; }
                    photo = UploadFile("PhotoTicketDeCaisse", garantie.Id, ".jpg", ".png");
                    if (!string.IsNullOrWhiteSpace(photo)) { gar.PhotoTicketDeCaisse = photo; }
                    photo = UploadFile("PhotoFicherAnnexe", garantie.Id, ".jpg", ".png", ".pdf", ".doc", ".docx");
                    if (!string.IsNullOrWhiteSpace(photo)) { gar.PhotoFicherAnnexe = photo; }

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (BadImageFormatException ex)
                {
                    ModelState.AddModelError(ex.FileName, ex.Message);
                }
                catch (Exception exe)
                {
                    ModelState.AddModelError("", exe.Message);
                }
            }
            return View(garantie);
        }

        // GET: Garanties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garantie garantie = db.Garanties.Find(id);
            if (garantie == null)
            {
                return HttpNotFound();
            }
            if (garantie.UserId != WebSecurity.CurrentUserId)
            {
                return new HttpUnauthorizedResult("Bad User");
            }
            return View(garantie);
        }

        // POST: Garanties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Garantie garantie = db.Garanties.Find(id);
            if (garantie.UserId != WebSecurity.CurrentUserId)
            {
                return new HttpUnauthorizedResult("Bad User");
            }
            db.Garanties.Remove(garantie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
