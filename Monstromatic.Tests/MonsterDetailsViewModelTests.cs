using Monstromatic.ViewModels;
using NUnit.Framework;

namespace Monstromatic.Tests
{
    [TestFixture]
    class MonsterDetailsViewModelTests
    {
        private const int StartLevel = 3;
        [Test]
        public void TestAdvantage()
        {
            var viewModel = new MonsterDetailsViewModel();

            viewModel.Level = StartLevel;
            viewModel.HasDisadvantage = true;
            viewModel.HasAdvantage = true;

            Assert.That(viewModel.HasDisadvantage, Is.False);
            Assert.That(viewModel.Level, Is.EqualTo(StartLevel + 1));
        }

        [Test]
        public void TestDisadvantage()
        {
            var viewModel = new MonsterDetailsViewModel();

            viewModel.Level = StartLevel;
            viewModel.HasAdvantage = true;
            viewModel.HasDisadvantage = true;

            Assert.That(viewModel.HasAdvantage, Is.False);
            Assert.That(viewModel.Level, Is.EqualTo(StartLevel - 1));
        }
    }
}
