using FluentAssertions;
using Monstromatic.Models;
using NUnit.Framework;

namespace Monstromatic.Tests.Models
{
    [TestFixture]
    class FeatureBaseTests
    {
        [Test]
        public void TestEquality()
        {
            var feature1 = new TestFeature(nameof(TestFeature));
            var feature2 = new TestFeature(nameof(TestFeature));

            feature1.Should().Be(feature2);
        }

        [Test]
        public void TestNotEquality()
        {
            var feature1 = new TestFeature(nameof(TestFeature));
            var feature2 = new TestFeature("123");

            feature1.Should().NotBe(feature2);
        }

        [Test]
        public void TestGetHashCodeMatch()
        {
            var feature1 = new TestFeature(nameof(TestFeature));
            feature1.GetHashCode().Should().Be(feature1.GetHashCode());
        }

        [Test]
        public void TestGetHashCodeDiffers()
        {
            var feature1 = new TestFeature(nameof(TestFeature));
            var feature2 = new TestFeature("123");

            feature1.GetHashCode().Should().NotBe(feature2.GetHashCode());
        }

        [Test]
        public void TestCompareByReference()
        {
            var feature1 = new TestFeature(nameof(TestFeature));
            var feature2 = new TestFeature(nameof(TestFeature));

            // ReSharper disable once PossibleUnintendedReferenceComparison
            (feature1 == feature2).Should().BeFalse();
        }

        private class TestFeature : FeatureBase
        {
            public override string Id { get; }

            public override string DisplayName => "FeatureForTest";

            public TestFeature(string id)
            {
                Id = id;
            }
        }
    }
}