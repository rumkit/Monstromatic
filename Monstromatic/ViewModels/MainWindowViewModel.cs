using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reflection;
using DynamicData;
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

        public IEnumerable<int> AvailableQualities => Enumerable.Range(1, 5);

        [Reactive]
        public int SelectedQuality { get; set; }

        public IEnumerable<FeatureViewModel> Features { get; }

        public SourceList<FeatureBase> SelectedFeatures { get; }

        public ReactiveCommand<Unit, Unit> GenerateMonsterCommand { get; }

        private readonly IFeatureRepository _featureRepository;

        public MainWindowViewModel(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;

            var canGenerateMonster = this
                .WhenAnyValue(x => x.Name, x => x.SelectedQuality,
                    (name, quality) => !string.IsNullOrWhiteSpace(name) && quality > 0);

            GenerateMonsterCommand = ReactiveCommand.Create(GenerateMonster, canGenerateMonster);

            SelectedFeatures = new SourceList<FeatureBase>();

            Features = GetFeatures();

            this.WhenAnyValue(x => x.IsGroup)
                .Subscribe(b =>
                {
                    if (b)
                    {
                        AddFeatureOnce(new MassAttackFeature());
                        AddFeatureOnce(new GroupFeature());
                    }
                    else
                    {
                        SelectedFeatures.Remove(new MassAttackFeature());
                        GroupCount = null;
                    }
                });
        }

        private void AddFeatureOnce(FeatureBase featureToAdd)
        {
            if (!SelectedFeatures.Items.Contains(featureToAdd))
                SelectedFeatures.Add(featureToAdd);
        }

        private IEnumerable<FeatureViewModel> GetFeatures()
        {
            return _featureRepository.GetFeatures()
                .Where(f => f != null)
                .Select(f => new FeatureViewModel(f, SelectedFeatures))
                .OrderBy(f => f.DisplayName);
        }

        private void GenerateMonster()
        {
            if (SelectedFeatures.Items.FirstOrDefault(f => f.Id == nameof(GroupFeature)) is GroupFeature groupFeature)
                groupFeature.Count = GroupCount ?? 0;

            var monster = new MonsterDetailsViewModel(Name, SelectedQuality, SelectedFeatures.Items);
            var window = new MonsterDetailsView(monster);
            window.Show();
            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            SelectedFeatures.Clear();
            Name = string.Empty;
            IsGroup = false;
        }
    }
}
