using System.Collections.Generic;
using System.Linq;
using MesGaranties.Api.Models.User;
using MesGaranties.Core.Models;

namespace MesGaranties.Api.Models.ExtensionsMethod
{
    internal static class UsersExtentions
    {
        #region method d'extention user

        internal static UserModel ToUserModel(this Core.Models.User user)
        {

            return new UserModel()
            {
                Id = user.Id,
                Name = user.Name,
                Mail = user.Mail
            };
        }

        internal static IEnumerable<UserModel> ToUserModels(this IEnumerable<Core.Models.User> users)
        {
            return users.Select(u => ToUserModel(u));
        }

        #endregion

        #region token

        internal static TokenModel ToTokenModel(this Token token)
        {
            return new TokenModel()
            {
                Token = token.Value,
                Expiration = token.ExpirationDate
            };
        }

        #endregion
    }
}