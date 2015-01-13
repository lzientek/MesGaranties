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
    public class ConnectionViewModel : INotifyPropertyChanged
    {
        private string _mail = string.Empty;
        private string _password = string.Empty;
        private bool _isConnecting;

        public string Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public bool IsConnecting
        {
            get { return _isConnecting; }
            set
            {
                _isConnecting = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
