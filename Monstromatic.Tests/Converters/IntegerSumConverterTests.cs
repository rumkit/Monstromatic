using System.Collections.Generic;
using FluentAssertions;
using Monstromatic.Converters;
using NUnit.Framework;

namespace Monstromatic.Tests.Converters
{
    [TestFixture]
    class IntegerSumConverterTests
    {
        [Test]
        public void TestConvert()
        {
            var converter = new IntegerSumConverter();

            var result = converter.Convert(new List<object>(){ 1, 2, 3, 4, 5 }, null, null, null);

            result.Should().BeOfType<string>();
            result.ToString().Should().Be("15");
        }
    }
}
