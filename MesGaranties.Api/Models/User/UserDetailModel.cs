using System;
using MesGaranties.Api.Helpers.Json;
using Newtonsoft.Json;

namespace MesGaranties.Api.Models.User
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
