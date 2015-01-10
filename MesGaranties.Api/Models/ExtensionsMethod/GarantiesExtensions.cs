using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MesGaranties.Api.Models.Garantie;

namespace MesGaranties.Api.Models.ExtensionsMethod
{
    internal static class GarantiesExtensions
    {
        internal static GarantieModel ToGarantieModel(this Core.Models.Garantie garantie)
        {
            return new GarantieModel
            {
                Id = garantie.Id,
                Name = garantie.Name,
                EndDate = garantie.FinDeGarantie,
                PhotoProduit = garantie.PhotoProduit
            };
        }
        internal static GarantieDetailModel ToGarantieDetailModel(this Core.Models.Garantie garantie)
        {
            return new GarantieDetailModel
            {
                Name = garantie.Name,
                Id = garantie.Id,
                EndDate = garantie.FinDeGarantie,
                PhotoProduit = garantie.PhotoProduit,
                CreationDate = garantie.CreationDate,
                LastModificationDate = garantie.LastModificationDate,
                FichierTicketDeCaisse = garantie.PhotoTicketDeCaisse,
                FichierAnnexe = garantie.PhotoFicherAnnexe,
                Commentaire = garantie.Commentaire
            };
        }
        internal static IEnumerable<GarantieModel> ToGarantieModel(this IEnumerable<Core.Models.Garantie> garanties)
        {
            return garanties.Select(ToGarantieModel);
        }

        internal static void ModifGarantie(this GarantieModifModel garantie, ref Core.Models.Garantie gar)
        {
            if (garantie.Name != null) { gar.Name = garantie.Name; }
            if (garantie.EndDate != null) { gar.FinDeGarantie = garantie.EndDate; }
            if (garantie.Commentaire != null) { gar.Commentaire = garantie.Commentaire; }
        }

        internal static Core.Models.Garantie ToGarantie(this GarantieCreateModel garantie)
        {
            return new Core.Models.Garantie
            {
                Name = garantie.Name,
                Commentaire = garantie.Commentaire,
                FinDeGarantie = garantie.EndDate,
                CreationDate = DateTime.Now,
                LastModificationDate = DateTime.Now,
            };
        }
    }
}
