// DansTesComs -> DansTesComs.WebSite ->AuthConfig.cs
// fichier créée le 06/07/2014 a 16:21
// par lucas zientek ( lucas )

using System;
using DansTesComs.WebSite.Filters;
using WebMatrix.WebData;

namespace MesGaranties.WebSite
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