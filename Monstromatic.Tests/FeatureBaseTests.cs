using Monstromatic.Models;
using NUnit.Framework;

namespace Monstromatic.Tests
{
    [TestFixture]
    class FeatureBaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestEquality()
        {
            var feature1 = new TestFeature(nameof(TestFeature));
            var feature2 = new TestFeature(nameof(TestFeature));

            Assert.That(feature1, Is.EqualTo(feature2));
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
            public override string Name { get; }

            public TestFeature(string name)
            {
                Name = name;
            }
        }
    }
}