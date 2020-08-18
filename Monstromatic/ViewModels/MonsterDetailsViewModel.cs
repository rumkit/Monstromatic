using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Monstromatic.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Monstromatic.ViewModels
{
    public class MonsterDetailsViewModel : ViewModelBase
    {
        [Reactive]
        public string Name { get; set; }

        private int _level;

        public int Level
        {
            get => _level + GetLevelModifier();
            set => this.RaiseAndSetIfChanged(ref _level, value);
        }

        public int UnitsCount { get; }

        public IEnumerable<FeatureBase> DescriptiveFeatures => Features.Where(f => !string.IsNullOrEmpty(f.Description));

        public List<FeatureBase> Features { get; set; }

        // ReSharper disable once UnassignedGetOnlyAutoProperty
        public int Stamina { [ObservableAsProperty] get; }

        // ReSharper disable once UnassignedGetOnlyAutoProperty
        public int Bravery { [ObservableAsProperty] get; }

        [Reactive]
        public bool HasAdvantage { get; set; }

        [Reactive]
        public bool HasDisadvantage { get; set; }

        public bool IsBerserkOrCoward =>
            Features.Any(x => x.Id == nameof(CowardFeature) || x.Id == nameof(BerserkFeature)) && !IsGroup;

        public bool IsGroup => UnitsCount > 0;

        public bool HasRegularCounters => !IsGroup && !IsBerserkOrCoward;

        public MonsterDetailsViewModel()
        {
            Features = new List<FeatureBase>();

            this.WhenAnyValue(x => x.HasAdvantage).Subscribe(x =>
            {
                if (x)
                    HasDisadvantage = false;
                this.RaisePropertyChanged(nameof(Level));
            });

            this.WhenAnyValue(x => x.HasDisadvantage).Subscribe(x =>
            {
                if (x)
                    HasAdvantage = false;
                this.RaisePropertyChanged(nameof(Level));
            });

            this.WhenAnyValue(x => x.Level)
                .Select(x => (Features.Sum(f => f.StaminaModifier) + 1) * x)
                .ToPropertyEx(this, x => x.Stamina);

            this.WhenAnyValue(x => x.Level)
                .Select(x => (Features.Sum(f => f.BraveryModifier) + 1) * x)
                .ToPropertyEx(this, x => x.Bravery);
        }

        public MonsterDetailsViewModel(string name, int baseLevel, IEnumerable<FeatureBase> features, int unitsCount = 0) : this()
        {
            Features.AddRange(features);
            Name = name;
            Level = baseLevel;
            UnitsCount = unitsCount;
        }

        private int GetLevelModifier()
        {
            int advantageModifier = (HasAdvantage ? 1 : 0) - (HasDisadvantage ? 1 : 0);
            int featuresModifier = Features.Sum(f => f.LevelModifier);
            return advantageModifier + featuresModifier;
        }
    }
}
