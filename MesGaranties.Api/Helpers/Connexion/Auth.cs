using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MesGaranties.Core.Models;

namespace MesGaranties.Api.Helpers.Connexion
{
    public static class Auth
    {
        private static volatile User _actualUser;
        private static bool _isConnected = false;

        internal static void SetUser(User user)
        {
            _actualUser = user;
            _isConnected = user != null;
        }

        public static bool IsConnected
        {
            get { return _isConnected; }
        }

        public static User ActualUser { get { return _actualUser; } }

        public static int CurrentId { get { return _isConnected?_actualUser.Id:-1; } }
        public static Token CurrentToken { get { return _isConnected?_actualUser.Token:null; } }
    }
}
