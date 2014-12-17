using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesGaranties.Core.Models
{
    partial class Token
    {

        public Token()
        {
            
        }

        public Token(string token)
        {
            SetNewToken(token);
        }

        public void SetNewToken(string token)
        {
            this.CreationDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now.AddHours(4);
            this.Value = token;
        }
    }
}
