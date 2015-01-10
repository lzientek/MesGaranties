using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MesGaranties.Api.Helpers.Json;
using Newtonsoft.Json;

namespace MesGaranties.Api.Models.Garantie
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
