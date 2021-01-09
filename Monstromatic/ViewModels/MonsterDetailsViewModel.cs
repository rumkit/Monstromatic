using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
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

        [Reactive]
        public int HitCounter { get; set; }

        [Reactive]
        public bool IsGroup { get; set; }

        public ReactiveCommand<Unit, Unit> ResetHitCounterCommand { get; }

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

            this.WhenAnyValue(x => x.IsGroup).Subscribe(_ => this.RaisePropertyChanged(nameof(Level)));

            this.WhenAnyValue(x => x.Level)
                .Select(x => (Features.Sum(f => f.StaminaModifier) + 1) * x)
                .ToPropertyEx(this, x => x.Stamina);

            this.WhenAnyValue(x => x.Level)
                .Select(x => (Features.Sum(f => f.BraveryModifier) + 1) * x)
                .ToPropertyEx(this, x => x.Bravery);


            ResetHitCounterCommand = ReactiveCommand.Create(ResetHitCounter);
        }
        

        public MonsterDetailsViewModel(string name, int baseLevel, IEnumerable<FeatureBase> features) : this()
        {
            Features.AddRange(features);
            Name = name;
            Level = baseLevel;
        }

        private void ResetHitCounter()
        {
            HitCounter = 0;
        }

        private int GetLevelModifier()
        {
            int advantageModifier = (HasAdvantage ? 1 : 0) - (HasDisadvantage ? 1 : 0);
            int featuresModifier = Features.Sum(f => f.LevelModifier);
            int groupModifier = IsGroup ? 1 : 0;
            return advantageModifier + featuresModifier + groupModifier;
        }
    }
}
