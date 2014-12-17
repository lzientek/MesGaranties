using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesGaranties.Api.Models.User
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
