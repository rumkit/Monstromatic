using DynamicData;
using FluentAssertions;
using Monstromatic.Utils;
using NUnit.Framework;

namespace Monstromatic.Tests.Utils
{
    [TestFixture]
    class SourceListExtensions
    {
        [Test]
        public void TestAddOnce()
        {
            var sourceList = new SourceList<int>();

            sourceList.AddOnce(1);
            sourceList.AddOnce(2);
            sourceList.AddOnce(1);

            sourceList.Items.Should().BeEquivalentTo(1, 2);
        }
    }
}
