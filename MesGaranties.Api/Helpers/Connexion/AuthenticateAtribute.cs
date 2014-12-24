using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using MesGaranties.Core.Models;

namespace MesGaranties.Api.Helpers.Connexion
{
    public class AuthenticateAtribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var cookie = actionContext.RequestContext.RouteData.Values["token"];
            if (cookie == null)
            {
                throw new Exception("Not connected");
            }
            else
            {
                var db = new MesGarantiesEntities();
                var token = db.Tokens.FirstOrDefault(t => t.Value == (string)cookie);
                if (token != null) { Auth.SetUser(token.User); }
                else
                {
                    throw new Exception("invalide token");
                }
            }
        }
    }
}
