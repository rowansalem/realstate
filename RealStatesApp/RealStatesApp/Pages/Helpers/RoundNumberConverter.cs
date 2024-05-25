using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace RealStatesApp.Pages.Helpers
{
    public class RoundNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal decimalValue)
            {
                return Math.Round(decimalValue).ToString("N0");
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
