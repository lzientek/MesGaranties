﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace MesGaranties.WinPhone.Converter
{
    public class NotConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool v = (bool) value;
            return !v;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool v = (bool)value;
            return !v;
        }
    }
}
