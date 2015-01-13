using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Data.Xml.Dom;
using MesGaranties.WinPhone.Core.ApiConnector.Models.Garantie;
using MesGaranties.WinPhone.ViewModels;

namespace MesGaranties.WinPhone.Core
{
    public class ApiData
    {
        public const string ServerUri = "http://192.168.1.64:8042";
        private const string savePath = "apidata.xml";
        public ApiData()
        {
        }

        private ApiConnector.ApiConnector _apiConnector;
        private ConnectionViewModel _cvm;
        private GarantiesViewModel _garantiesViewModel;

        [XmlIgnore]
        public ApiConnector.ApiConnector ApiConnector
        {
            get
            {
                if (_apiConnector == null)
                {
                    _apiConnector = new ApiConnector.ApiConnector(Mail, Password);
                }
                return _apiConnector;
            }
            set { _apiConnector = value; }
        }

        public string Mail { get; set; }
        public string Password { get; set; }

        [XmlIgnore]
        public ConnectionViewModel ConnectionViewModel
        {
            get
            {
                if (_cvm == null)
                {
                    _cvm = new ConnectionViewModel()
                    {
                        IsConnecting = false,
                        Mail = Mail,
                        Password = Password,
                    };
                }
                return _cvm;
            }
        }

        [XmlIgnore]
        public GarantiesViewModel GarantiesViewModel
        {
            get
            {
                if (_garantiesViewModel == null)
                {
                    List<GarantieModel> gs = ApiConnector.GarantieConnector.GetGaranties().Result as List<GarantieModel>;

                    _garantiesViewModel = new GarantiesViewModel()
                    {
                        Garanties = new ObservableCollection<GarantieViewModel>(gs.ToGarantieViewModels())
                    };
                }
                return _garantiesViewModel;
            }
            set { _garantiesViewModel = value; }
        }

        public async Task<bool> Login()
        {
            Mail = _cvm.Mail;
            Password = _cvm.Password;
            Save();
            ApiConnector = new ApiConnector.ApiConnector(Mail, Password);
            await ApiConnector.Login();
            return ApiConnector.IsConnected;
        }

        public void Save()
        {
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();
            try
            {
                using (var isoStream = new IsolatedStorageFileStream(savePath, FileMode.Create, isoStore))
                {
                    using (var writer = new StreamWriter(isoStream))
                    {
                        var ser = new XmlSerializer(typeof (ApiData));
                        ser.Serialize(writer, this);
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }
        public static ApiData Load()
        {
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();
            try
            {
                using (var isoStream = new IsolatedStorageFileStream(savePath, FileMode.Open, isoStore))
                {
                    using (var reader = new StreamReader(isoStream))
                    {

                        var dser = new XmlSerializer(typeof(ApiData));
                        return (ApiData)dser.Deserialize(reader);


                    }
                }
            }
            catch (Exception)
            {
                return new ApiData();
            }
        }

    }

    internal static class Extentions
    {
        internal static GarantieViewModel ToGarantieViewModel(this GarantieModel garantie)
        {
            return new GarantieViewModel()
            {
                Name = garantie.Name,
                Id = garantie.Id,
                PhotoProduit = garantie.PhotoProduit,
                EndDate = garantie.EndDate
            };
        }
        internal static IEnumerable<GarantieViewModel> ToGarantieViewModels(this IEnumerable<GarantieModel> garantie)
        {
            return garantie.Select(ToGarantieViewModel);
        }
    }
}
