//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MesGaranties.Core.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Garantie
    {
        public int Id { get; set; }
        public System.DateTime CreationDate { get; set; }
        public System.DateTime LastModificationDate { get; set; }
        public string Name { get; set; }
        public string PhotoProduit { get; set; }
        public string PhotoTicketDeCaisse { get; set; }
        public string PhotoFicherAnnexe { get; set; }
        public string Commentaire { get; set; }
        public Nullable<System.DateTime> FinDeGarantie { get; set; }
        public int UserId { get; set; }
    
        public virtual User User { get; set; }
    }
}
