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
        private string _mail;
        private string _password;
        private bool _isConnecting;

        public string Mail
        {
            get { return _mail; }
            set
            {
                if (value == _mail) return;
                _mail = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged();
            }
        }

        public bool IsConnecting
        {
            get { return _isConnecting; }
            set
            {
                if (value.Equals(_isConnecting)) return;
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
