using System;
using Newtonsoft.Json;

namespace MesGaranties.WinPhone.Core.ApiConnector.Models.Garantie
{
    public class GarantieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonConverter(typeof(JsonUnixDateConverter))]
        public DateTime? EndDate { get; set; }
        public string PhotoProduit { get; set; }
    }
}
