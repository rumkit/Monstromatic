using System;
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
        [Reactive]
        public bool IsGroup { get; set; }

        [Reactive]
        public int? GroupCount { get; set; }

        [Reactive]
        public string Name { get; set; }

        [Reactive] public IEnumerable<string> Qualities { get; set; }

        [Reactive]
        public string SelectedQuality { get; set; }

        public IEnumerable<FeatureViewModel> Features { get; }

        public ReactiveCommand<Unit, Unit> GenerateMonsterCommand { get; }
        
        private readonly IFeatureController _featureController = new FeatureController();
        private readonly IAppSettingsProvider _settingsProvider;

        public MainWindowViewModel(IAppSettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;

            var canGenerateMonster = this
                .WhenAnyValue(x => x.Name, x => x.SelectedQuality,
                    (name, quality) => !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(quality));

            GenerateMonsterCommand = ReactiveCommand.Create(GenerateMonster, canGenerateMonster);

            Qualities = settingsProvider.Settings.MonsterQualities.Select(x => x.Key);

            Features = GetFeatureViewModels();

            //todo: remove?
            this.WhenAnyValue(x => x.IsGroup)
                .Subscribe(b =>
                {
                    if (b)
                    {
                        //todo: remove?
                        _featureController.AddFeature(GetFeature("MassAttack"));
                        _featureController.AddFeature(GetFeature("Group"));
                    }
                    else
                    {
                        _featureController.RemoveFeature(GetFeature("Group"));
                        GroupCount = null;
                    }
                });
        }

        private MonsterFeature GetFeature(string key)
        {
            return _settingsProvider.Features.Single(f => f.Key == key);
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
            //if (_featureController.SelectedFeatures.Items.FirstOrDefault(f => f.Id == nameof(GroupFeature)) is GroupFeature groupFeature)
            //    groupFeature.Count = GroupCount ?? 0;

            var monster = new MonsterDetailsViewModel(Name, _settingsProvider.Settings.MonsterQualities[SelectedQuality], _featureController.CreateBundle());
            var window = new MonsterDetailsView(monster);
            window.Show();
        }

        private void SetDefaultValues()
        {
            _featureController.SelectedFeatures.Clear();
            Name = string.Empty;
            IsGroup = false;
        }
    }
}
