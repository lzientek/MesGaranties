using System;
using Newtonsoft.Json;

namespace MesGaranties.WinPhone.Core.ApiConnector.Models
{
    public class UserDetailModel
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        [JsonConverter(typeof(JsonUnixDateConverter))]
        public DateTime CreationDate { get; set; }

    }

    
}
