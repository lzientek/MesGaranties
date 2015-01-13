using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using MesGaranties.WinPhone.Core;

namespace MesGaranties.WinPhone.Converter
{
    public class PathToBitmapConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = value as string;
            if (!string.IsNullOrEmpty(path))
                try
                {
                    var image = new BitmapImage(new Uri(string.Format("{0}{1}", ApiData.ServerUri, path)));
                    return image;
                }
                catch (Exception )
                {
                    return new BitmapImage();
                }
            return new BitmapImage();
        }
        

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
