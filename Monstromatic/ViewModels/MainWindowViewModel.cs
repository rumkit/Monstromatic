using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Monstromatic.Data;
using Monstromatic.Models;
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

        public IEnumerable<FeatureViewModel> Features => GetFeatureViewModels();
        public IEnumerable<string> Qualities => _settingsProvider.Settings.MonsterQualities.Select(x => x.Key);
        public ReactiveCommand<Unit, Unit> GenerateMonsterCommand { get; }
        public ReactiveCommand<Unit, Unit> ShowAboutCommand { get; }
        
        public Interaction<MonsterDetailsViewModel, Unit> ShowNewMonsterWindow { get; } = new ();
        public Interaction<Unit, Unit> ShowAboutDialog { get; } = new ();

        public MainWindowViewModel(IAppSettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;

            var canGenerateMonster = this
                .WhenAnyValue(x => x.Name, x => x.SelectedQuality,
                    (name, quality) => !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(quality));
            
            GenerateMonsterCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var monster = new MonsterDetailsViewModel(Name, _settingsProvider.Settings.MonsterQualities[SelectedQuality], _featureController.CreateBundle());
                await ShowNewMonsterWindow.Handle(monster);
            }, canGenerateMonster);
            
            ShowAboutCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                await ShowAboutDialog.Handle(Unit.Default);
            });
        }

        private IEnumerable<FeatureViewModel> GetFeatureViewModels()
        {
            return _settingsProvider.Features
                .Where(f => f is { IsHidden: false })
                .Select(f => new FeatureViewModel(f, _featureController))
                .OrderBy(f => f.DisplayName);
        }
    }
}
