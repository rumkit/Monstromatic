using FluentAssertions;
using Monstromatic.Converters;
using NUnit.Framework;

namespace Monstromatic.Tests.Converters
{
    [TestFixture]
    class BoolInverseConverterTests
    {
        [TestCase(true)]
        [TestCase(false)]
        public void Convert_Valid(bool value)
        {
            var converter = new BoolInverseConverter();

            var result = converter.Convert(value, null, null, null);

            result.Should().BeOfType<bool>();
            ((bool)result).Should().Be(!value);
        }

        [TestCase(true)]
        public void ConvertBack_Valid(bool value)
        {
            var converter = new BoolInverseConverter();

            var result = converter.ConvertBack(value, null, null, null);

            result.Should().BeOfType<bool>();
            ((bool)result).Should().Be(!value);
        }
    }
}
