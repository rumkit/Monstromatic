using System.Collections.Generic;
using FluentAssertions;
using Monstromatic.Models;
using Monstromatic.ViewModels;
using NUnit.Framework;

namespace Monstromatic.Tests.ViewModels
{
    [TestFixture]
    class MonsterDetailsViewModelTests
    {
        private const int StartLevel = 3;
        [Test]
        public void TestAdvantage()
        {
            var viewModel = new MonsterDetailsViewModel
            {
                Level = StartLevel,
                HasDisadvantage = true,
                HasAdvantage = true
            };


            viewModel.HasDisadvantage.Should().BeFalse();
            viewModel.Level.Should().Be(StartLevel + 1);
        }

        [Test]
        public void TestDisadvantage()
        {
            var viewModel = new MonsterDetailsViewModel
            {
                Level = StartLevel,
                HasAdvantage = true,
                HasDisadvantage = true
            };


            viewModel.HasAdvantage.Should().BeFalse();
            viewModel.Level.Should().Be(StartLevel - 1);
        }

        // [Test]
        // public void TestIsGroupFalseAndUnitsCountIsZero()
        // {
        //     var viewModel = new MonsterDetailsViewModel();
        //
        //     viewModel.IsGroup.Should().BeFalse();
        //     viewModel.UnitsCount.Should().Be(0);
        // }
        //
        // [Test]
        // public void TestIsGroupTrueAndUnitsCountEqualsGroupCount()
        // {
        //     const int groupCount = 55;
        //     var viewModel = new MonsterDetailsViewModel(
        //         "testVM",
        //         1,
        //         new[] { new GroupFeature() { Count = groupCount } }
        //     );
        //
        //     viewModel.IsGroup.Should().BeTrue();
        //     viewModel.UnitsCount.Should().Be(groupCount);
        // }
        //
        // [TestCase(1, 3, 5)]
        // [TestCase(2, 6, 10)]
        // [TestCase(3, 9, 15)]
        // public void TestDefaultModifiers(int baseLevel, int expectedBravery, int expectedStamina)
        // {
        //     var viewModel = new MonsterDetailsViewModel(
        //         "testVM",
        //         baseLevel,
        //         new List<FeatureBase>() { new TestFeature(), new TestFeature() }
        //     );
        //
        //     viewModel.Bravery.Should().Be(expectedBravery);
        //     viewModel.Stamina.Should().Be(expectedStamina);
        // }
        //
        // [TestCaseSource(nameof(AdvancedCountersTestCaseSource))]
        // public void TestHasAdvancedCounters(MonsterDetailsViewModel viewModel, bool hasRegularCounters,
        //     bool hasGroupCounters, bool hasCowardOrBerserkCounters)
        // {
        //     viewModel.HasRegularCounters.Should().Be(hasRegularCounters);
        //     viewModel.IsGroup.Should().Be(hasGroupCounters);
        //     viewModel.IsBerserkOrCoward.Should().Be(hasCowardOrBerserkCounters);
        // }

        private static IEnumerable<TestCaseData> AdvancedCountersTestCaseSource()
        {
            var defaultVm = new MonsterDetailsViewModel("testVM", 1, new FeatureBase[0]);
            var berserkVm = new MonsterDetailsViewModel("testVM", 1, new[] { new BerserkFeature() });
            var cowardVm = new MonsterDetailsViewModel("testVM", 1, new[] { new CowardFeature() });
            var groupVm = new MonsterDetailsViewModel("testVM", 1, new[] { new GroupFeature() });

            yield return new TestCaseData(defaultVm, true, false, false);
            yield return new TestCaseData(berserkVm, false, false, true);
            yield return new TestCaseData(cowardVm, false, false, true);
            yield return new TestCaseData(groupVm, false, true, false);
        }


        private class TestFeature : FeatureBase
        {
            public override string Id => "test-feature";
            public override string DisplayName => "test-feature";

            // public override int BraveryModifier => 1;
            // public override int StaminaModifier => 2;
        }
    }
}
