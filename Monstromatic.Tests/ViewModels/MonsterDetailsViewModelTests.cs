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

        [Test]
        public void TestIsGroupFalseAndHitCounterIsZero()
        {
            var viewModel = new MonsterDetailsViewModel();

            viewModel.IsGroup.Should().BeFalse();
            viewModel.HitCounter.Should().Be(0);
        }

        [TestCase(1, 2, 2)]
        [TestCase(2, 4, 4)]
        [TestCase(3, 6, 6)]
        public void TestDefaultModifiers(int baseLevel, int expectedAttack, int expectedDefence)
        {
            var viewModel = new MonsterDetailsViewModel(
                "testVM",
                baseLevel,
                new [] { TestFeature }
            );

            viewModel.Attack.Should().Be(expectedAttack);
            viewModel.Defence.Should().Be(expectedDefence);
        }

        private static MonsterFeature TestFeature => new ()
        {
            Key = "test-feature",
            DisplayName = "test-feature",
            AttackModifier = 1,
            DefenceModifier = 1,
            LevelModifier = 0
        };
    }
}
