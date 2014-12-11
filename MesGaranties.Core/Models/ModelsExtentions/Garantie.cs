using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DansTesComs.Ressources.Garantie;
namespace MesGaranties.Core.Models
{
    [MetadataType(typeof(GarantieMetadata))]
    partial class Garantie
    {
        public string Status
        {
            get
            {
                if (FinDeGarantie != null && FinDeGarantie > DateTime.Now)
                {
                    return "sousGarantie";
                }
                return "garantieExpire";
            }
        }
    }

    public class GarantieMetadata
    {


        [MaxLength(250, ErrorMessageResourceType = typeof(GarantieRessources),ErrorMessageResourceName = "Nom_trop_long")]
        [Display(ResourceType = typeof(GarantieRessources),Name = "Nom_produit")]
        [Required(ErrorMessageResourceType = typeof(GarantieRessources),ErrorMessageResourceName = "Name_required")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(GarantieRessources),Name = "Nom_photo_produit")]
        public string PhotoProduit { get; set; }

        [Display(ResourceType = typeof(GarantieRessources), Name = "Nom_photo_ticket")]
        public string PhotoTicketDeCaisse { get; set; }

        [Display(ResourceType = typeof(GarantieRessources), Name = "Nom_fichier_annexe")]
        public string PhotoFicherAnnexe { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(GarantieRessources), Name = "Nom_commentaire")]
        public string Commentaire { get; set; }

        [DataType(DataType.Date,ErrorMessageResourceType = typeof(GarantieRessources),ErrorMessageResourceName = "Error_format_date")]
        [Display(ResourceType = typeof(GarantieRessources), Name = "Nom_Date_Fin_de_garantie")]
        [Required(ErrorMessageResourceType = typeof(GarantieRessources), ErrorMessageResourceName = "End_date_required")]
        public Nullable<DateTime> FinDeGarantie { get; set; }

    }
}
