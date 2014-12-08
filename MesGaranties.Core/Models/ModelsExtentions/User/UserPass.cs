using System;
using System.ComponentModel.DataAnnotations;
using DansTesComs.Ressources.User;

namespace MesGaranties.Core.Models
{
    [MetadataType(typeof(UserPassMetadata))]
    public class UserPass : User
    {
        public string Pass { get; set; }
        public string ConfirmationPass { get; set; }

        public User ToUser()
        {
            return new User
            {
                Id = Id,
                Mail = Mail,
                Name = Name,
                Firstname = Firstname,

            };
        }
    }

    public class UserPassMetadata:UserMetadata
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof (UserRessources), ErrorMessageResourceName = "PassObligatoire")]
        [Display(ResourceType = typeof (UserRessources), Name = "PassLabel")]
        public string Pass { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "PassObligatoire")]
        [Display(ResourceType = typeof(UserRessources), Name = "PassLabel")]
        [Compare("Pass", ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "UserPassMetadata_ConfirmationPass")]
        public string ConfirmationPass { get; set; }

        [Display(ResourceType = typeof(UserRessources), Name = "EmailLabel")]
        [EmailAddress(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "EmailError", ErrorMessage = null)]
        [Required(ErrorMessageResourceType = typeof(UserRessources), ErrorMessageResourceName = "EmailObligatoire")]
        public string Mail { get; set; }

    }
}
