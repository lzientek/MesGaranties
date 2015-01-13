using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MesGaranties.WinPhone.Core;
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
            ConnectionViewModel = (Application.Current as App).ApiData.ConnectionViewModel;
            DataContext = ConnectionViewModel;
            
        }

        private void SeConnecterButton_OnClick(object sender, RoutedEventArgs e)
        {
            ConnectionViewModel.IsConnecting = true;
            if ((App.Current as App).ApiData.Login())
            {
                ConnectionViewModel.IsConnecting = false;
                NavigationService.Navigate(new Uri("/Page/GarantiesPage.xaml", UriKind.Relative));
            }
            else
            {
                ConnectionViewModel.IsConnecting = false;
                MessageBox.Show(Core.Resources.Resources.LoginFail);
            }
        }

        
    }
}