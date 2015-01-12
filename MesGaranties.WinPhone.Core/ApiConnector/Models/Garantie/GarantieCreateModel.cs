using System;
using Newtonsoft.Json;

namespace MesGaranties.WinPhone.Core.ApiConnector.Models.Garantie
{
    public class GarantieCreateModel
    {
        public string Name { get; set; }

        [JsonConverter(typeof(JsonUnixDateConverter))]
        public DateTime? EndDate { get; set; }
        
        public string Commentaire { get; set; }
    }
}
