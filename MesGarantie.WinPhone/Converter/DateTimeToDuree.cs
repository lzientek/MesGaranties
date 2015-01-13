using System;
using System.Globalization;
using System.Windows.Data;
using MesGaranties.WinPhone.Core.Resources;

namespace MesGaranties.WinPhone.Converter
{
    public class DateTimeToDuree : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = value is DateTime ? (DateTime)value : new DateTime();
            var ts = date - DateTime.Today;

            if (ts.Days > 0)
                return string.Format("{0} {1}", ts.Days, Resources.Days);
            
            
            return string.Format("{0}", Resources.GarantieEnded);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
