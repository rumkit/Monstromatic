using System;
using Avalonia.Controls;
using FluentAssertions;
using Monstromatic.Converters;
using NUnit.Framework;

namespace Monstromatic.Tests.Converters;

[TestFixture]
public class DoubleToGridLengthConverterTests
{
    [Test]
    public void Convert_Valid()
    {
        var converter = new DoubleToGridLengthConverter();

        var result = converter.Convert(1.23, null, null, null);

        result.Should().BeOfType<GridLength>();
        ((GridLength)result).Value.Should().Be(1.23);
    }

    [Test]
    public void ConvertBack_Throws()
    {
        var converter = new DoubleToGridLengthConverter();

        var action = () => converter.ConvertBack(new GridLength(), null, null, null);

        action.Should().Throw<NotImplementedException>();
    }
}
