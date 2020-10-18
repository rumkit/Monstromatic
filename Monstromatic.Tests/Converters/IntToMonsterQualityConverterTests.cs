using System.Collections.Generic;
using FluentAssertions;
using Monstromatic.Converters;
using NUnit.Framework;

namespace Monstromatic.Tests.Converters
{
    [TestFixture]
    class IntToMonsterQualityConverterTests
    {
        [Test]
        public void TestConvert()
        {
            var converter = new IntToMonsterQualityConverter();

            var result = converter.Convert(new[] { 1, 3, 5 }, null, null, null);

            result.Should().BeAssignableTo<IEnumerable<string>>();
            result.Should().BeEquivalentTo(new object[]{"Слабый", "Элита", "Каноничный"});
        }

        [Test]
        public void TestConvertBackWithNullValue()
        {
            var converter = new IntToMonsterQualityConverter();

            var result = converter.ConvertBack(null, null, null, null);

            result.Should().BeOfType<int>();
            result.Should().Be(-1);
        }

        [TestCase("Слабый", 1)]
        [TestCase("Обыватель", 2)]
        [TestCase("Элита", 3)]
        [TestCase("Сюжетный", 4)]
        [TestCase("Каноничный", 5)]
        [TestCase("NotAQuality", 0)]
        public void TestConvertBack(string value, int expectedResult)
        {
            var converter = new IntToMonsterQualityConverter();

            var result = converter.ConvertBack(value, null, null, null);

            result.Should().BeOfType<int>();
            result.Should().Be(expectedResult);
        }
    }
}
