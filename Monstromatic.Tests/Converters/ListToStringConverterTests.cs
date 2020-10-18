using System;
using FluentAssertions;
using Monstromatic.Converters;
using NUnit.Framework;

namespace Monstromatic.Tests.Converters
{
    [TestFixture]
    class ListToStringConverterTests
    {
        [Test]
        public void TestConvert()
        {
            var converter = new ListToStringConverter();

            var result = converter.Convert(new [] {"one", "two", "three"},null,null, null);

            result.Should().Be($"one{Environment.NewLine}two{Environment.NewLine}three");
        }

        [Test]
        public void TestConvertBack()
        {
            var converter = new ListToStringConverter();

            Action action = () => converter.ConvertBack(null,null,null, null);

            action.Should().Throw<NotImplementedException>();
        }

        [Test]
        public void TestConvertWithWrongValue()
        {
            var converter = new ListToStringConverter();

            Action action = () => converter.Convert(new [] {1, 2, 3},null,null, null);

            action.Should().Throw<InvalidOperationException>();
        }
    }
}
