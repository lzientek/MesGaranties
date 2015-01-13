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
        public MainPage()
        {
            InitializeComponent();
            DataContext = App.ApiData.ConnectionViewModel;
            
        }

        private async void SeConnecterButton_OnClick(object sender, RoutedEventArgs e)
        {
            App.ApiData.ConnectionViewModel.IsConnecting = true;
            if (await App.ApiData.Login())
            {
                App.ApiData.ConnectionViewModel.IsConnecting = false;
                NavigationService.Navigate(new Uri("/Page/GarantiesPage.xaml", UriKind.Relative));
            }
            else
            {
                App.ApiData.ConnectionViewModel.IsConnecting = false;
                MessageBox.Show(Core.Resources.Resources.LoginFail);
            }
        }

        
    }
}