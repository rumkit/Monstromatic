using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using DynamicData;
using Monstromatic.Data;
using Monstromatic.Models;
using Monstromatic.Views;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Monstromatic.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IFeatureController _featureController = new FeatureController();
        private readonly IAppSettingsProvider _settingsProvider;
        
        [Reactive]
        public string Name { get; set; }

        [Reactive]
        public string SelectedQuality { get; set; }

        public IEnumerable<FeatureViewModel> Features { get; }
        public IEnumerable<string> Qualities { get; }
        public ReactiveCommand<Unit, Unit> GenerateMonsterCommand { get; }

        public MainWindowViewModel(IAppSettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
            Qualities = settingsProvider.Settings.MonsterQualities.Select(x => x.Key);
            Features = GetFeatureViewModels();

            var canGenerateMonster = this
                .WhenAnyValue(x => x.Name, x => x.SelectedQuality,
                    (name, quality) => !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(quality));

            GenerateMonsterCommand = ReactiveCommand.Create(GenerateMonster, canGenerateMonster);
        }

        private IEnumerable<FeatureViewModel> GetFeatureViewModels()
        {
            return _settingsProvider.Features
                .Where(f => f is { IsHidden: false })
                .Select(f => new FeatureViewModel(f, _featureController))
                .OrderBy(f => f.DisplayName);
        }

        private void GenerateMonster()
        {
            var monster = new MonsterDetailsViewModel(Name, _settingsProvider.Settings.MonsterQualities[SelectedQuality], _featureController.CreateBundle());
            var window = new MonsterDetailsView(monster);
            window.Show();
        }

        private void SetDefaultValues()
        {
            _featureController.SelectedFeatures.Clear();
            Name = string.Empty;
        }
    }
}
