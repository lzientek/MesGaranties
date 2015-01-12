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

namespace MesGaranties.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public ConnectionViewModel ConnectionViewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();
            DataContext = ConnectionViewModel;
            
        }
    }
}