using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MesGaranties.Api.Models.ExtensionsMethod;
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
        [Route("Garanties")]
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
        [ResponseType(typeof(Garantie))]
        public IHttpActionResult GetGarantie([FromUri]int id)
        {
            Garantie garantie = db.Garanties.Find(id);
            if (garantie == null)
            {
                return NotFound();
            }

            return Ok(garantie);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="garantie"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Garanties/{id}")]
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGarantie(int id, Garantie garantie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != garantie.Id)
            {
                return BadRequest();
            }

            db.Entry(garantie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GarantieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="garantie"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Garanties")]
        [Authorize]
        [ResponseType(typeof(Garantie))]
        public IHttpActionResult PostGarantie(Garantie garantie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Garanties.Add(garantie);
            db.SaveChanges();

            return Created(string.Format("Garanties/{0}", garantie.Id),garantie);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Garanties/{id}")]
        [Authorize]
        [ResponseType(typeof(Garantie))]
        public IHttpActionResult DeleteGarantie(int id)
        {
            Garantie garantie = db.Garanties.Find(id);
            if (garantie == null)
            {
                return NotFound();
            }

            db.Garanties.Remove(garantie);
            db.SaveChanges();

            return Ok(garantie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GarantieExists(int id)
        {
            return db.Garanties.Count(e => e.Id == id) > 0;
        }
    }
}