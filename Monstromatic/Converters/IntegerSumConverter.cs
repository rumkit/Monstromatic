using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;

namespace Monstromatic.Converters
{
    public class IntegerSumConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            var integers = values.OfType<int>();
            return integers.Sum().ToString();
        }
    }
}
