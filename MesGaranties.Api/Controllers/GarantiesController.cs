using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using MesGaranties.Api.Models.ExtensionsMethod;
using MesGaranties.Api.Models.Garantie;
using MesGaranties.Core.Models;
using WebMatrix.WebData;

namespace MesGaranties.Api.Controllers
{
    public class GarantiesController : ApiController
    {
        private MesGarantiesEntities db = new MesGarantiesEntities();

        /// <summary>
        /// Get garanties from the connected user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [Route("Me/Garanties")]
        [ResponseType(typeof(IEnumerable<Garantie>))]
        public IHttpActionResult GetGarantie()
        {
            var actualUser = db.Users.Find(WebSecurity.CurrentUserId);

            return Ok(actualUser.Garanties.ToList().ToGarantieModel());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Garanties/{id}")]
        [Authorize]
        [ResponseType(typeof(GarantieDetailModel))]
        public IHttpActionResult GetGarantie([FromUri]int id)
        {
            var garantie = db.Garanties.Find(id);
            if (garantie == null || garantie.UserId != WebSecurity.CurrentUserId)
            {
                return NotFound();
            }

            return Ok(garantie.ToGarantieDetailModel());
        }

        /// <summary>
        /// Modify a garantie by his id
        /// </summary>
        /// <param name="id">garantie id</param>
        /// <param name="garantie">modification</param>
        /// <returns></returns>
        [HttpPut]
        [Route("Garanties/{id}")]
        [Authorize]
        [ResponseType(typeof(GarantieDetailModel))]
        public IHttpActionResult PutGarantie(int id, GarantieModifModel garantie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gar = db.Garanties.Find(id);
            if (gar == null) { return NotFound(); }

            try
            {
                garantie.ModifGarantie(ref gar);
                gar.LastModificationDate = DateTime.Now;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return new ExceptionResult(ex,this);
            }
            return Ok(gar.ToGarantieDetailModel());
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="garantie"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Me/Garanties")]
        [Authorize]
        [ResponseType(typeof(GarantieDetailModel))]
        public IHttpActionResult PostGarantie(GarantieCreateModel garantie)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var gar = garantie.ToGarantie();
            gar.UserId = WebSecurity.CurrentUserId;
            db.Garanties.Add(gar);
            db.SaveChanges();

            return Created(string.Format("Garanties/{0}", gar.Id), gar.ToGarantieDetailModel());
        }

        /// <summary>
        /// delete a garantie by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Garanties/{id}")]
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteGarantie(int id)
        {
            Garantie garantie = db.Garanties.Find(id);
            if (garantie == null || garantie.UserId != WebSecurity.CurrentUserId)
            {
                return NotFound();
            }

            db.Garanties.Remove(garantie);
            db.SaveChanges();

            return Ok();
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