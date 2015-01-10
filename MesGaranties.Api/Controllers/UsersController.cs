using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using LucasHelpers.Math;
using MesGaranties.Api.Models.ExtensionsMethod;
using MesGaranties.Api.Models.User;
using MesGaranties.Core.Models;
using WebMatrix.WebData;

namespace MesGaranties.Api.Controllers
{
    public class UsersController : ApiController
    {
        private MesGarantiesEntities db = new MesGarantiesEntities();

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [Route("Users")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<UserModel> GetUsers()
        {
            return db.Users.ToUserModels();
        }

        /// <summary>
        /// put user details by id
        /// </summary>
        /// <param name="id">user id</param>
        /// <param name="user">user values</param>
        /// <returns></returns>
        [Route("Users/{id}")]
        [HttpPut]
        [Authorize]
        [ResponseType(typeof(UserDetailModel))]
        public IHttpActionResult PutUser(int id, User user)
        {
            return StatusCode(HttpStatusCode.NotImplemented);
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (id != user.Id) { return BadRequest(); }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                return new ExceptionResult(ex, this);
            }

        }

        /// <summary>
        /// get the actual user
        /// </summary>
        /// <returns></returns>
        [Route("Me")]
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(UserDetailModel))]
        public IHttpActionResult Me()
        {
            return Ok(db.Users.Find(WebSecurity.CurrentUserId).ToUserDetailModel());
        }

        /// <summary>
        /// Method de connexion
        /// </summary>
        /// <param name="user">model de connexion</param>
        /// <returns>connected user</returns>
        [Route("Connection")]
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult Connexion([FromBody]UserConnexionModel user)
        {
            if (user == null)
            {
                return new StatusCodeResult(HttpStatusCode.NotFound, this);
            }
            if (WebSecurity.Login(user.Mail, user.Password))
            {
                return Ok();
            }

            return StatusCode(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Users/{id}")]
        [HttpDelete]
        [Authorize]
        public IHttpActionResult DeleteUser(int id)
        {
            if (WebSecurity.CurrentUserId != id) { return StatusCode(HttpStatusCode.Forbidden); }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
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

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}