using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MesGaranties.WpfClient.Helper;

namespace MesGaranties.WpfClient
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Api api = new Api();
        public MainWindow()
        {
            InitializeComponent();
            api.Connection("luc@zientek.fr", "r0Qj6Ink");
            api.SendFile(@"C:\Users\lucas\Pictures\580166_598186063559288_2029291777_n.jpg", 13);
        }
    }
}
