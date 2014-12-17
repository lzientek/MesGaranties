// DansTesComs -> DansTesComs.WebSite ->AuthConfig.cs
// fichier créée le 06/07/2014 a 16:21
// par lucas zientek ( lucas )

using System;
using WebMatrix.WebData;

namespace MesGaranties.Api.Helpers.Connexion
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
            }
        }
    }
}