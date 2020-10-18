using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Monstromatic.Models;
using NUnit.Framework;

namespace Monstromatic.Tests.Models
{
    [TestFixture]
    class FeatureControllerTests
    {
        private FeatureController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new FeatureController();
        }

        [Test]
        public void TestAddFeature()
        {
            _controller.AddFeature(new FlyingFeature());

            _controller.SelectedFeatures.Items.Should().BeEquivalentTo(new FlyingFeature());
        }

        [Test]
        public void TestAddFeatureDouble()
        {
            _controller.AddFeature(new FlyingFeature());
            _controller.AddFeature(new FlyingFeature());

            _controller.SelectedFeatures.Items.Should().BeEquivalentTo(new FlyingFeature());
        }

        [Test]
        public void TestAddFeatureDoubleIncluded()
        {
            _controller.AddFeature(new MassAttackFeature());
            _controller.AddFeature(new GroupFeature());

            _controller.SelectedFeatures.Items.Should().BeEquivalentTo(new MassAttackFeature(), new GroupFeature());
        }

        [Test]
        public void TestAddFeatureAndIncludedFeatures()
        {
            _controller.AddFeature(new GiantFeature());

            _controller.SelectedFeatures.Items.Should().BeEquivalentTo(new GiantFeature(), new BigSizeFeature());
        }

        [Test]
        public void TestRemoveFeature()
        {
            _controller.AddFeature(new GiantFeature());
            _controller.RemoveFeature(new GiantFeature());

            _controller.SelectedFeatures.Items.Should().BeEquivalentTo(new BigSizeFeature());
        }

        [TestCaseSource(nameof(ExclusiveFeaturesTestCaseSource))]
        public void TestCreateBundleExclusiveFeatures(FeatureBase[] features, FeatureBase[] expectedFeatures)
        {
            foreach (var feature in features)
            {
                _controller.AddFeature(feature);
            }

            IEnumerable<FeatureBase> bundle = _controller.CreateBundle();

            bundle.Should().BeEquivalentTo(expectedFeatures.ToList());
        }

        private static IEnumerable<TestCaseData> ExclusiveFeaturesTestCaseSource()
        {
            yield return new TestCaseData(
                new FeatureBase[] {new GroupFeature(), new SmallSizeFeature()},
                new FeatureBase[] {new GroupFeature(), new MassAttackFeature() });
            yield return new TestCaseData(
                new FeatureBase[] {new PowerfulAttackFeature(), new SmallSizeFeature()},
                new FeatureBase[] { });
        }
    }
}
