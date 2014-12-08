using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DansTesComs.Ressources.CommentaireExterne;
using DansTesComs.WebSite.Filters;
using MesGaranties.Core.Models;
using WebMatrix.WebData;

namespace MesGaranties.WebSite.Controllers
{
    [InitializeSimpleMembership]
    public class GarantiesController : Controller
    {
        private MesGarantiesEntities db = new MesGarantiesEntities();

        // GET: Garanties
        public ActionResult Index()
        {
            var garanties = db.Garanties.Where(g => g.UserId == WebSecurity.CurrentUserId);
            return View(garanties.ToList());
        }

        // GET: Garanties/Details/5
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
            return View(garantie);
        }

        // GET: Garanties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Garanties/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,PhotoProduit,PhotoTicketDeCaisse,PhotoFicherAnnexe,Commentaire,FinDeGarantie")] Garantie garantie)
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
                    garantie.PhotoProduit = UploadFile("PhotoProduit", garantie.Id, new[] { ".jpg", ".png" });
                    garantie.PhotoTicketDeCaisse = UploadFile("PhotoTicketDeCaisse", garantie.Id, new[] { ".jpg", ".png" });
                    garantie.PhotoFicherAnnexe = UploadFile("PhotoFicherAnnexe", garantie.Id,
                        new[] { ".jpg", ".png", ".pdf", ".doc", ".docx" });
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
                    throw new BadImageFormatException("Extension du fichier non valide.", fileName);
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
            ViewBag.UserId = new SelectList(db.Users, "Id", "Mail", garantie.UserId);
            return View(garantie);
        }

        // POST: Garanties/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreationDate,LastModificationDate,Name,PhotoProduit,PhotoTicketDeCaisse,PhotoFicherAnnexe,Commentaire,FinDeGarantie,UserId")] Garantie garantie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garantie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Mail", garantie.UserId);
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
            return View(garantie);
        }

        // POST: Garanties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Garantie garantie = db.Garanties.Find(id);
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
