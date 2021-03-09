using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;

namespace Monstromatic.Converters
{
    public class IsCheckedToMonsterQualityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parameterParsed = int.TryParse(parameter.ToString(), out var parameterValue);
            return parameterParsed switch
            {
                true => (int) value == parameterValue,
                _ => false
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var parameterParsed = int.TryParse(parameter.ToString(), out var parameterValue);
            return parameterParsed switch
            {
                true when (bool) value => parameterValue,
                _ => -1
            };
        }
    }
}