using System;
using Avalonia.Controls;
using FluentAssertions;
using Monstromatic.Converters;
using Monstromatic.Models;
using NUnit.Framework;

namespace Monstromatic.Tests.Converters;

[TestFixture]
public class GridHeightFeatureCountConverterTests
{
    [TestCase(9, 4, 5, 29)]
    [TestCase(-1, 3, 12, 35)]
    public void Convert_Valid(int padding, int unitsPerItem, int itemCount, int expectedResult)
    {
        var converter = new GridHeightFeatureCountConverter();
        var features = new MonsterFeature[itemCount];
        var parameters = $"{padding};{unitsPerItem}";

        var result = converter.Convert(features, null, parameters, null);

        result.Should().BeOfType<int>();
        ((int)result).Should().Be(expectedResult);
    }

    [Test]
    public void ConvertBack_Throws()
    {
        var converter = new GridHeightFeatureCountConverter();

        var action = () => converter.ConvertBack(new GridLength(), null, null, null);

        action.Should().Throw<NotImplementedException>();
    }
}
