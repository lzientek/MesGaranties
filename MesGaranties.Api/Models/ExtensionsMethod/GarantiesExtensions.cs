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
    }
}
