using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MesGaranties.Api.Helpers.Json;
using Newtonsoft.Json;

namespace MesGaranties.Api.Models.Garantie
{
    public class GarantieDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [JsonConverter(typeof(JsonUnixDateConverter))]
        public DateTime CreationDate { get; set; }
        
        [JsonConverter(typeof(JsonUnixDateConverter))]
        public DateTime LastModificationDate { get; set; }
        
        [JsonConverter(typeof(JsonUnixDateConverter))]
        public DateTime? EndDate { get; set; }
        public string PhotoProduit { get; set; }
        public string FichierTicketDeCaisse { get; set; }
        public string FichierAnnexe { get; set; }
        public string Commentaire { get; set; }
    }
}
