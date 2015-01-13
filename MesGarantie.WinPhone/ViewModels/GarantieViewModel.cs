using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MesGaranties.WinPhone.Annotations;

namespace MesGaranties.WinPhone.ViewModels
{
    public class GarantieViewModel:INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? EndDate { get; set; }
        public string PhotoProduit { get; set; }
        public string FichierTicketDeCaisse { get; set; }
        public string FichierAnnexe { get; set; }
        public string Commentaire { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
