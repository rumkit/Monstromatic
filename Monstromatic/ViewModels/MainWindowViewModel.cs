using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Monstromatic.Data;
using Monstromatic.Models;
using Monstromatic.Utils;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Monstromatic.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public IProcessHelper ProcessHelper { get; }
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
        public ReactiveCommand<string, Unit> ShowSettingsCommand { get; }
        public ReactiveCommand<Unit, Unit> ResetSettingsCommand { get; }

        public Interaction<MonsterDetailsViewModel, Unit> ShowNewMonsterWindow { get; } = new ();
        public Interaction<Unit, Unit> ShowAboutDialog { get; } = new ();
        public Interaction<Unit, bool> ConfirmResetChanges { get; } = new();
        
        public MainWindowViewModel(IAppSettingsProvider settingsProvider, IProcessHelper processHelper)
        {
            ProcessHelper = processHelper;
            _settingsProvider = settingsProvider;

            var canGenerateMonster = this
                .WhenAnyValue(x => x.Name, x => x.SelectedQuality,
                    (name, quality) => !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(quality));
            
            GenerateMonsterCommand = ReactiveCommand.CreateFromTask(GenerateNewMonster, canGenerateMonster);
            ShowAboutCommand = ReactiveCommand.CreateFromTask(async () => await ShowAboutDialog.Handle(Unit.Default));
            ShowSettingsCommand = ReactiveCommand.CreateFromTask<string>(ShowSettings);
            ResetSettingsCommand = ReactiveCommand.CreateFromTask(ResetSettings);
        }

        private async Task ResetSettings()
        {
            var result = await ConfirmResetChanges.Handle(Unit.Default);
            if (result)
            {
                _settingsProvider.Reset();
                RefreshControls();
            }
        }

        private async Task GenerateNewMonster()
        {
            var monster = new MonsterDetailsViewModel(Name, _settingsProvider.Settings.MonsterQualities[SelectedQuality], _featureController.CreateBundle());
            await ShowNewMonsterWindow.Handle(monster);
        }

        private async Task ShowSettings(string path)
        {
            await ProcessHelper.StartNewAndWaitAsync(path);
            RefreshControls();
        }

        private void RefreshControls()
        {
            _settingsProvider.Reload();
            this.RaisePropertyChanged(nameof(Features));
            this.RaisePropertyChanged(nameof(Qualities));
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
