using System;
using System.ComponentModel.DataAnnotations;
using MesGaranties.Api.Helpers.Json;
using Newtonsoft.Json;

namespace MesGaranties.Api.Models.Garantie
{
    public class GarantieCreateModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [JsonConverter(typeof(JsonUnixDateConverter))]
        public DateTime? EndDate { get; set; }
        
        public string Commentaire { get; set; }
    }
}
