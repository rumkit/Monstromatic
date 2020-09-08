using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;

namespace Monstromatic.Converters
{
    public class IntToMonsterQualityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as IEnumerable<int>)?.Select(x => Qualities[x]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return -1;
            return Qualities.FirstOrDefault(kvp => kvp.Value == value.ToString()).Key;
        }

        private static readonly Dictionary<int, string> Qualities = new Dictionary<int, string>()
        {
            [1] = "Слабый",
            [2] = "Обыватель",
            [3] = "Элита",
            [4] = "Сюжетный",
            [5] = "Каноничный"
        };
    }
}
