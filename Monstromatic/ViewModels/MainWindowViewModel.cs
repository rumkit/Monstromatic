using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using DynamicData;
using Monstromatic.Data;
using Monstromatic.Models;
using Monstromatic.Utils;
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

        private readonly IFeatureRepository _featureRepository;
        private readonly IFeatureController _featureController;
        private readonly MonstromaticSettings _settings;

        public MainWindowViewModel(IFeatureRepository featureRepository, IFeatureController featureController, IDataStorage<MonstromaticSettings> settingsStorage)
        {
            _featureRepository = featureRepository;
            _featureController = featureController;


            _settings = settingsStorage.Read();

            var canGenerateMonster = this
                .WhenAnyValue(x => x.Name, x => x.SelectedQuality,
                    (name, quality) => !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(quality));

            GenerateMonsterCommand = ReactiveCommand.Create(GenerateMonster, canGenerateMonster);

            Qualities = _settings.MonsterQualities.Select(x => x.Key);

            Features = GetFeatureViewModels();

            this.WhenAnyValue(x => x.IsGroup)
                .Subscribe(b =>
                {
                    if (b)
                    {
                        _featureController.AddFeature(new MassAttackFeature());
                        _featureController.AddFeature(new GroupFeature());
                    }
                    else
                    {
                        _featureController.RemoveFeature(new GroupFeature());
                        GroupCount = null;
                    }
                });
        }

        private IEnumerable<FeatureViewModel> GetFeatureViewModels()
        {
            return _featureRepository.GetFeatures()
                .Where(f => f != null)
                .Select(f => new FeatureViewModel(f, _featureController))
                .OrderBy(f => f.DisplayName);
        }

        private void GenerateMonster()
        {
            if (_featureController.SelectedFeatures.Items.FirstOrDefault(f => f.Id == nameof(GroupFeature)) is GroupFeature groupFeature)
                groupFeature.Count = GroupCount ?? 0;

            var monster = new MonsterDetailsViewModel(Name, _settings.MonsterQualities[SelectedQuality], _featureController.CreateBundle());
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
