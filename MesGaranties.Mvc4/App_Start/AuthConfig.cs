using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using MesGaranties.Mvc4.Models;
using WebMatrix.WebData;

namespace MesGaranties.Mvc4
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            try
            {

                WebSecurity.InitializeDatabaseConnection("DansTesComsSqlServeur", "Users", "id", "Mail", true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Impossible d'initialiser la base de données ASP.NET Simple Membership. Pour plus d'informations, consultez la page http://go.microsoft.com/fwlink/?LinkId=256588", ex);
            }
        }
    }
}
