﻿using System;
using System.Data.Entity;
using System.Threading;
using System.Web.Mvc;
using MesGaranties.Core.Models;

namespace DansTesComs.WebSite.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // S'assurer qu'ASP.NET Simple Membership est initialisé une seule fois par démarrage d'application
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<MesGarantiesEntities>(null);

                //try
                //{

                //    WebSecurity.InitializeDatabaseConnection("DansTesComsSqlServeur", "Users", "id", "Pseudo", true);
                //}
                //catch (Exception ex)
                //{
                //    throw new InvalidOperationException("Impossible d'initialiser la base de données ASP.NET Simple Membership. Pour plus d'informations, consultez la page http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                //}
            }
        }
    }
}