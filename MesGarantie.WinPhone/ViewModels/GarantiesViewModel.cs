using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesGaranties.WinPhone.ViewModels
{
    public class GarantiesViewModel
    {
        public ObservableCollection<GarantieViewModel> Garanties { get; set; }

        public ObservableCollection<GarantieViewModel> GarantiesTermine { get; set; }
        public ObservableCollection<GarantieViewModel> GarantiesCommence { get; set; }
        public GarantiesViewModel()
        {
            Garanties = new ObservableCollection<GarantieViewModel>();
            GarantiesCommence = new ObservableCollection<GarantieViewModel>();
            GarantiesTermine = new ObservableCollection<GarantieViewModel>();

            Garanties.CollectionChanged += GarantiesOnCollectionChanged;
        }

        private void GarantiesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            GarantiesTermine.Clear();
            GarantiesCommence.Clear();
            foreach (var garanty in Garanties)
            {
                if (garanty.EndDate >= DateTime.Today)
                {
                    GarantiesCommence.Add(garanty);
                }
                else
                {
                    GarantiesTermine.Add(garanty);
                }
            }
        }
    }
}
