using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesGaranties.Core.Models
{
    partial class Garantie
    {
        public string Status
        {
            get
            {
                if (FinDeGarantie != null && FinDeGarantie > DateTime.Now)
                {
                    return "sousGarantie";
                }
                return "garantieExpire";
            }
        }
    }
}
