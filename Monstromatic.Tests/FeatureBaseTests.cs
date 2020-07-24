using Monstromatic.Models;
using NUnit.Framework;

namespace Monstromatic.Tests
{
    [TestFixture]
    class FeatureBaseTests
    {
        [Test]
        public void TestEquality()
        {
            var feature1 = new TestFeature(nameof(TestFeature));
            var feature2 = new TestFeature(nameof(TestFeature));

            Assert.That(feature1, Is.EqualTo(feature2));
        }

        [Test]
        public void TestNotEquality()
        {
            var feature1 = new TestFeature(nameof(TestFeature));
            var feature2 = new TestFeature("123");

            Assert.That(feature1, Is.Not.EqualTo(feature2));
        }

        [Test]
        public void TestCompareByReference()
        {
            var feature1 = new TestFeature(nameof(TestFeature));
            var feature2 = new TestFeature(nameof(TestFeature));

            // ReSharper disable once PossibleUnintendedReferenceComparison
            Assert.That(feature1 == feature2, Is.False);
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