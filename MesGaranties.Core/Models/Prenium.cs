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
    
    public partial class Prenium
    {
        public int Id { get; set; }
        public bool Prenium1 { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public int UserId { get; set; }
    
        public virtual User User { get; set; }
    }
}
