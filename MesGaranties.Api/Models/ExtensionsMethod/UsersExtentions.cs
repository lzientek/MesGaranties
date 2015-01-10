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

        internal static UserDetailModel ToUserDetailModel(this Core.Models.User user)
        {

            return new UserDetailModel()
            {
                Id = user.Id,
                Lastname = user.Name,
                Firstname = user.Firstname,
                Mail = user.Mail,
                CreationDate = user.CreationDate
            };
        }

        internal static IEnumerable<UserModel> ToUserModels(this IEnumerable<Core.Models.User> users)
        {
            return users.Select(ToUserModel);
        }

        #endregion


    }
}