using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MesGaranties.WinPhone.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MesGaranties.WinPhone.UserControls
{
    public partial class GarantieUControl : UserControl
    {
        public GarantieUControl()
        {
            InitializeComponent();
            DataContext = Garantie;
        }

        public static readonly DependencyProperty GarantieDp =
        DependencyProperty.Register("Garantie", typeof(GarantieViewModel),
        typeof(GarantieUControl), new PropertyMetadata(null));

        public GarantieViewModel Garantie
        {
            get { return (GarantieViewModel)GetValue(GarantieDp); }
            set { SetValue(GarantieDp, value); }
        }
    }
}
