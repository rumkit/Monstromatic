using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;
using Monstromatic.Models;

namespace Monstromatic.Converters;

public class GridHeightFeatureCountConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var (paddingUnits, unitsPerItem) = GetParameters(parameter.ToString());
        var enumerable = value as IEnumerable<MonsterFeature>;
        return paddingUnits + enumerable.Count() * unitsPerItem;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    private (int PaddingUnites, int UnitsPerItem) GetParameters(string parameterString)
    {
        var parameters = parameterString.Split(';', StringSplitOptions.RemoveEmptyEntries);
        return (int.Parse(parameters[0]), int.Parse(parameters[1]));
    }
}
