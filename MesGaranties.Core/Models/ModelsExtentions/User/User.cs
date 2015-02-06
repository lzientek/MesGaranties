// DansTesComs -> DansTesComs.WebSite ->UserExt.cs
// fichier créée le 09/07/2014 a 19:56
// par lucas zientek ( lucas )

using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using DansTesComs.Ressources.User;
using LucasHelpers.StringHelper;

namespace MesGaranties.Core.Models
{
    [MetadataType(typeof (UserMetadata))]
    public partial class User
    {
        public bool RememberMe { get; set; }

        public string GetGravatarLink(int size =40)
        {
            return Mail.MailToGravatar(40);
        }
    }


    public class UserMetadata
    {
        [Display(ResourceType = typeof(UserRessources), Name = "EmailLabel")]
        [EmailAddress(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "EmailError",ErrorMessage = null)]
        [Required(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "EmailObligatoire")]
        public string Mail { get; set; }

        [MaxLength(80, ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "LongueurMax80")]
        [Display(ResourceType = typeof(UserRessources), Name = "NomLabel")]
        public string Name { get; set; }

        [MaxLength(80, ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "LongueurMax80")]
        [Display(ResourceType = typeof(UserRessources), Name = "PrenomLabel")]
        public string Firstname { get; set; }

        [Display(ResourceType = typeof(UserRessources), Name = "RememberMeLabel")]
        public bool RememberMe { get; set; }
    }
}